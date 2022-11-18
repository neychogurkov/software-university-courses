namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CustomAttributes
                    .Any(a => typeof(MyValidationAttribute).IsAssignableFrom(a.AttributeType)))
                .ToArray();

            foreach (var property in properties)
            {
                MyValidationAttribute[] validationAttributes = property
                    .GetCustomAttributes()
                    .Where(a => typeof(MyValidationAttribute).IsAssignableFrom(a.GetType()))
                    .Select(a => (MyValidationAttribute)a)
                    .ToArray();

                foreach (var validationAttribute in validationAttributes)
                {
                    if (!validationAttribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
