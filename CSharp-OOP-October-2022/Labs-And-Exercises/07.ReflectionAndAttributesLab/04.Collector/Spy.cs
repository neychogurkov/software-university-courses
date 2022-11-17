namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(className);
            sb.AppendLine($"Class under investigation: {type}");

            object classInstance = Activator.CreateInstance(type);
            foreach (var fieldName in fields)
            {
                FieldInfo field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var property in properties)
            {
                if (!property.GetMethod.IsPublic)
                {
                    sb.AppendLine($"{property.GetMethod.Name} have to be public!");
                }
                if (!property.SetMethod.IsPrivate)
                {
                    sb.AppendLine($"{property.SetMethod.Name} have to be private!");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            MethodInfo[] getMethods = methods.Where(m => m.Name.StartsWith("get")).ToArray();
            MethodInfo[] setMethods = methods.Where(m => m.Name.StartsWith("set")).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var getMethod in getMethods)
            {
                sb.AppendLine($"{getMethod.Name} will return {getMethod.ReturnType}");
            }
            foreach (var setMethod in setMethods)
            {
                sb.AppendLine($"{setMethod.Name} will set field of {setMethod.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
