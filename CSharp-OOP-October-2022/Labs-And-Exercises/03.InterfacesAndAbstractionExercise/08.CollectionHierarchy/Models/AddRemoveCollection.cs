namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> items;
        public AddRemoveCollection()
        {
            items = new List<string>();
            AddIndexes = new List<int>();
            RemovedItems = new List<string>();
        }

        public List<int> AddIndexes { get; private set; }
        public List<string> RemovedItems { get; private set; }

        public int Add(string item)
        {
            items.Insert(0, item);
            AddIndexes.Add(0);
            return 0;
        }

        public string Remove()
        {
            string itemToRemove = items[items.Count - 1];
            RemovedItems.Add(itemToRemove);
            items.RemoveAt(items.Count - 1);
            return itemToRemove;
        }
    }
}
