using Logger.Core.Layouts.Contracts;

namespace Logger.ConsoleApp.Factories.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
