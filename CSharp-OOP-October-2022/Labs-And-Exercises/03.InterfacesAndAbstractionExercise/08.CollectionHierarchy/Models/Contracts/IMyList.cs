namespace CollectionHierarchy.Models.Contracts
{
    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}
