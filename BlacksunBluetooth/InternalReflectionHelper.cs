using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlacksunBluetooth
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
