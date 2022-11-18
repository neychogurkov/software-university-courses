namespace CommandPattern.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split();
            string commandName = cmdArgs[0];
            string[] invokeArgs = cmdArgs.Skip(1).ToArray();
            Type type = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");
            MethodInfo method = type.GetMethod("Execute");
            object instance = Activator.CreateInstance(type);

            string result = (string)method.Invoke(instance, new object[] {invokeArgs});
            return result;
        }
    }
}
