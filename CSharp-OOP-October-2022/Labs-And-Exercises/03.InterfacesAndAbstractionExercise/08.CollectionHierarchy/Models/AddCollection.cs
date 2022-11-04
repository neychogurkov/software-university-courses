namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class AddCollection : IAddCollection
    {
        private List<string> items;

        public AddCollection()
        {
            items = new List<string>();
            AddIndexes = new List<int>();
        }

        public List<int> AddIndexes { get; private set; }

        public int Add(string item)
        {
            items.Add(item);
            AddIndexes.Add(items.Count - 1);
            return items.Count - 1;
        }
    }
}
