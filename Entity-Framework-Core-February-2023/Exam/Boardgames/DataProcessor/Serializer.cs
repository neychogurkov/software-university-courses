namespace Boardgames.DataProcessor
{
    using Newtonsoft.Json;

    using Data;
    using ExportDto;
    using Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            xmlHelper = new XmlHelper();

            ExportCreatorDto[] creatorDtos = context.Creators
                .Where(c => c.Boardgames.Count > 0)
                .Select(c => new ExportCreatorDto
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    Boardgames = c.Boardgames.Select(b => new ExportBoardgameDto
                    {
                        Name = b.Name,
                        YearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.Name)
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            return xmlHelper.Serialize(creatorDtos, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var creatorsWithBoardgames = context.Sellers
                .Where(s => s.BoardgamesSellers.Count(bc => bc.Boardgame.YearPublished >= year && bc.Boardgame.Rating <= rating) > 0)
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bc => bc.Boardgame.YearPublished >= year && bc.Boardgame.Rating <= rating)
                    .Select(b => new
                    {
                        b.Boardgame.Name,
                        b.Boardgame.Rating,
                        b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(creatorsWithBoardgames, Formatting.Indented);
        }
    }
}