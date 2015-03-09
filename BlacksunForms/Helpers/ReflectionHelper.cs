using System.Reflection;

namespace Blacksun.XamForms.Helpers
{
    internal static class ReflectionHelper
    {

        public static bool PropertyExists(object obj, string PropertyName)
        {
            var properties = obj.GetType().GetRuntimeProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name == PropertyName)
                {
                    return true;
                }
            }

            return false;
        }

        public static void SetPropertyValueIfExists(this object obj, object value, string PropertyName)
        {

            if (PropertyExists(obj, PropertyName))
            {
                SetPropertyValue(obj, value, PropertyName);
            }

        }

        public static object GetPropertyValueIfExists(this object obj, string PropertyName,object defaultValue = null)
        {

            if (PropertyExists(obj, PropertyName))
            {
                return GetPropertyValue(obj,PropertyName);
            }
            else
            {
                return defaultValue;
            }

        }

        public static object SetPropertyValue(object obj, object value, string PropertyName)
        {
            var property = GetProperty(obj, PropertyName);

            PropertyInfo fieldPropertyInfo = property;

            var businessObjectPropValue = fieldPropertyInfo.GetValue(obj, null);


            fieldPropertyInfo.SetValue(obj, value, null);


            return null;
        }

        public static PropertyInfo GetProperty(this object obj, string PropertyName)
        {
            var properties = obj.GetType().GetRuntimeProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name == PropertyName)
                {
                    return propertyInfo;
                }
            }

            return null;
        }

        public static object GetPropertyValue(this object obj, string PropertyName)
        {
            var properties = obj.GetType().GetRuntimeProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name == PropertyName)
                {
                    var item = propertyInfo.GetValue(obj, null);
                    return item;
                }
            }

            return null;
        }

    }
}
