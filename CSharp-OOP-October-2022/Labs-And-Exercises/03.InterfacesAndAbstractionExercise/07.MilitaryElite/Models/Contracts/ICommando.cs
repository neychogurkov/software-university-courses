namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
