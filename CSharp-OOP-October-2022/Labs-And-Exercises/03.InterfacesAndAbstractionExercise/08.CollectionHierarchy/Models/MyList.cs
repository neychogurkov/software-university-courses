namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Contracts;

    public class MyList : IMyList
    {
        private List<string> items;
        public MyList()
        {
            items = new List<string>();
            AddIndexes = new List<int>();
            RemovedItems = new List<string>();
        }

        public int Used => items.Count;
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
            string itemToRemove = items[0];
            RemovedItems.Add(itemToRemove);
            items.RemoveAt(0);
            return itemToRemove;
        }
    }
}
