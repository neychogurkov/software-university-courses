using Logger.ConsoleApp.Factories.Contracts;
using Logger.ConsoleApp.Layouts;
using Logger.Core.Appenders.Contracts;
using Logger.Core.Layouts;
using Logger.Core.Layouts.Contracts;
using System;
namespace Logger.ConsoleApp.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;
            if(type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }

            return layout;
        }
    }
}
