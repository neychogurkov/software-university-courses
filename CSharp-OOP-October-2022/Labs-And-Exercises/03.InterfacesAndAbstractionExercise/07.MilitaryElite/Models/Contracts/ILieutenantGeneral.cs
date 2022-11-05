namespace MilitaryElite.Models.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> Privates { get; } 
    }
}
