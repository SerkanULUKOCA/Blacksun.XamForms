using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Bluetooth
{
    public static class ReflectionHelper
    {

        public static void SetPropertyValue(this object obj, object value, string PropertyName)
        {
            var property = GetProperty(obj, PropertyName);

            if (property != null)
            {
                property.SetValue(property, value, null);
            }

        }

        public static object SetPropertyValue(this object obj, object value, Type type)
        {
            var property = GetPropertyByType(obj, type);

            if (property == null)
                return null;

            property.SetValue(obj, value, null);

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

        public static PropertyInfo GetPropertyByType(this object obj, Type type)
        {
            var properties = obj.GetType().GetRuntimeProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.PropertyType == type)
                {
                    return propertyInfo;
                }
            }

            return null;
        }

        public static T GetPropertyValue<T>(this object obj, string PropertyName)
        {

            var value = GetPropertyValue(obj, PropertyName);

            return (T)value;

        }

        public static object GetPropertyValue(this object obj, string PropertyName)
        {

            if (obj != null)
            {
                var propertyInfo = GetProperty(obj, PropertyName);
                var item = propertyInfo.GetValue(obj, null);
                return item;
            }



            return null;
        }

        public static object GetPropertyValue(this object obj, Type type)
        {

            if (obj != null)
            {
                var propertyInfo = GetPropertyByType(obj, type);
                var item = propertyInfo.GetValue(obj, null);
                return item;
            }



            return null;
        }

        public static bool IsEqual(this object item, object otherItem)
        {
            return !IsObjectDirty(item, otherItem);
        }

        public static bool IsObjectDirty(object original, object Copy)
        {
            var originalproperties = original.GetType().GetRuntimeProperties();

            foreach (var propertyInfo in originalproperties)
            {
                var propertyname = propertyInfo.Name;

                var A = GetPropertyValue(original, propertyname);
                var B = GetPropertyValue(Copy, propertyname);

                if (A != null && B != null && !A.Equals(B))
                    return true;

                if (A == null && B != null)
                    return true;

                if (B == null && A != null)
                    return true;

            }

            return false;
        }

        public static void CopyTo(this object Source, object Destination)
        {
            foreach (var pS in Source.GetType().GetRuntimeProperties())
            {

                var isPrimitive = CheckIfPrimitive(pS);

                if (isPrimitive)
                {
                    var properties = Destination.GetType().GetRuntimeProperties();

                    var queryProperty = properties.FirstOrDefault(x => x.Name == pS.Name);

                    if (queryProperty != null && queryProperty.PropertyType == pS.PropertyType)
                    {
                        try
                        {
                            queryProperty.SetMethod.Invoke(Destination, new object[] { pS.GetMethod.Invoke(Source, null) });
                        }
                        catch (Exception)
                        {

                        }

                    }

                }

            }
        }

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

        public static object GetNotEmptyNonPrimitiveProperty(object obj)
        {
            var properties = obj.GetType().GetRuntimeProperties();

            foreach (var propertyInfo in properties)
            {
                var item = propertyInfo.GetValue(obj, null);
                if (item != null && item.GetType().Name != "Boolean")
                {
                    return item;
                }
            }

            return null;
        }

        public static object GetDefaultValue(this object value)
        {

            if (value == null)
                return null;

            var type = value.GetType();

            if (type == typeof(string))
            {
                return null;
            }

            if (type == typeof(DateTime))
            {
                return DateTime.MinValue;
            }

            if (type == typeof(decimal))
            {
                return 0;
            }

            if (type == typeof(double))
            {
                return 0;
            }

            if (type == typeof(String))
            {
                return "";
            }

            if (type == typeof(int))
            {
                return 0;
            }

            if (type == typeof(DateTime?))
            {
                return null;
            }

            if (type == typeof(decimal?))
            {
                return null;
            }

            if (type == typeof(double?))
            {
                return null;
            }

            if (type == typeof(int?))
            {
                return null;
            }

            return null;
        }

        public static bool CheckIfPrimitive(Type propertyType)
        {
            var type = propertyType;

            if (type == typeof(string))
            {
                return true;
            }

            if (type == typeof(DateTime))
            {
                return true;
            }

            if (type == typeof(decimal))
            {
                return true;
            }

            if (type == typeof(double))
            {
                return true;
            }

            if (type == typeof(String))
            {
                return true;
            }

            if (type == typeof(int))
            {
                return true;
            }

            if (type == typeof(DateTime?))
            {
                return true;
            }

            if (type == typeof(decimal?))
            {
                return true;
            }

            if (type == typeof(double?))
            {
                return true;
            }

            if (type == typeof(int?))
            {
                return true;
            }

            return false;
        }

        public static bool CheckIfPrimitive(PropertyInfo propertyInfo)
        {

            return CheckIfPrimitive(propertyInfo.PropertyType);

        }
        /*
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type type, Assembly extensionsAssembly)
        {
            var query = from t in extensionsAssembly.GetTypes()
                        where !t.IsGenericType && !t.IsNested
                        from m in t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                        where m.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false)
                        where m.GetParameters()[0].ParameterType == type
                        select m;

            return query;
        }*/

        /*
        public static MethodInfo GetExtensionMethod(this Type type, Assembly extensionsAssembly, string name)
        {
            return type.GetExtensionMethods(extensionsAssembly).FirstOrDefault(m => m.Name == name);
        }

        public static MethodInfo GetExtensionMethod(this Type type, Assembly extensionsAssembly, string name, Type[] types)
        {
            var methods = (from m in type.GetExtensionMethods(extensionsAssembly)
                           where m.Name == name
                           && m.GetParameters().Count() == types.Length + 1 // + 1 because extension method parameter (this)
                           select m).ToList();

            if (!methods.Any())
            {
                return default(MethodInfo);
            }

            if (methods.Count() == 1)
            {
                return methods.First();
            }

            foreach (var methodInfo in methods)
            {
                var parameters = methodInfo.GetParameters();

                bool found = true;
                for (byte b = 0; b < types.Length; b++)
                {
                    found = true;
                    if (parameters[b].GetType() != types[b])
                    {
                        found = false;
                    }
                }

                if (found)
                {
                    return methodInfo;
                }
            }

            return default(MethodInfo);
        }
        */

    }
}
