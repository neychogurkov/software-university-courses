namespace CollectionHierarchy.Models.Contracts
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }
}