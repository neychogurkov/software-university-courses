using Logger.ConsoleApp.Core;
using Logger.ConsoleApp.Core.Contracts;
using Logger.Core.Loggers.Contracts;

namespace Logger.ConsoleApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
