namespace Telephony.Models.Contracts
{
    public interface ISmartphone : IStationaryPhone
    {
        string Browse(string website);
    }
}
