namespace CollectionHierarchy.Core
{
    using Contracts;
    using IO.Contracts;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly AddCollection addCollection;
        private readonly AddRemoveCollection addRemoveCollection;
        private readonly MyList myList;

        private Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] items = this.reader.ReadLine().Split();

            foreach (var item in items)
            {
                this.addCollection.Add(item);
                this.addRemoveCollection.Add(item);
                this.myList.Add(item);
            }

            int countOfItemsToRemove = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < countOfItemsToRemove; i++)
            {
                this.addRemoveCollection.Remove();
                this.myList.Remove();
            }

            this.writer.WriteLine(string.Join(' ', this.addCollection.AddIndexes));
            this.writer.WriteLine(string.Join(' ', this.addRemoveCollection.AddIndexes));
            this.writer.WriteLine(string.Join(' ', this.myList.AddIndexes));
            this.writer.WriteLine(string.Join(' ', this.addRemoveCollection.RemovedItems));
            this.writer.WriteLine(string.Join(' ', this.myList.RemovedItems));
        }
    }
}
