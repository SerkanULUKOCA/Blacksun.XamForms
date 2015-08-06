using System.Linq;
using System.Reflection;

namespace BlacksunBluetoothWinPhone80
{
    internal static class InternalReflectionHelper
    {

        public static T GetPropertyValue<T>(this object item,string name)
        {
            var property = item.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == name);

            return (T) property.GetValue(item);

        }

    }
}
