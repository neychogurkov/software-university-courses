namespace Logger.Core.Layouts.Contracts
{
    using Models.Contracts;

    public interface IFormatter
    {
        string Format(IMessage message, ILayout layout);
    }
}
