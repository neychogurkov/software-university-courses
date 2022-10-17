using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = FindStock(companyName);

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.Portfolio.Remove(stock);
                this.MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }

        public Stock FindStock(string companyName) => this.Portfolio.Find(s => s.CompanyName == companyName);

        public Stock FindBiggestCompany() => this.Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
