namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}