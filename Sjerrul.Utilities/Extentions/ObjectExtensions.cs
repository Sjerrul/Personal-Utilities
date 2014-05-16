using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities.Extentions
{
    public static class ObjectExtensions
    {
        public static object GetPropertyValue(this object o, string propertyName)
        {
            Object retVal = GetPropValue(o, propertyName);
            if (retVal == null)
            {
                return null;
            }

            return retVal;
        }

        public static object GetPropertyType(this object o, string propertyName)
        {
            Type retVal = GetPropType(o, propertyName);
            if (retVal == null)
            {
                return null;
            }

            return retVal;
        }

        private static Object GetPropValue(object o, string name)
        {
            foreach (string part in name.Split('.'))
            {
                if (o == null)
                {
                    return null;
                }

                Type type = o.GetType();

                if (type.BaseType.Name != part)
                {
                    PropertyInfo info = type.GetProperty(part);
                    if (info == null)
                    {
                        return null;
                    }

                    o = info.GetValue(o, null);
                }
            }

            return o;
        }

        private static Type GetPropType(object o, string name)
        {
            foreach (string part in name.Split('.'))
            {
                if (o == null)
                {
                    return null;
                }

                Type type = o.GetType();

                PropertyInfo info = type.GetProperty(part);
                if (info == null)
                {
                    return null;
                }

                o = info.GetValue(o, null);
            }

            return o.GetType();
        }
    }
}
