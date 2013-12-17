using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sjerrul.Utilities.Session
{
    public static class SessionManager
    {
        public static void Add<T>(T o)
        {
            AssertSessionAvailable();            

            string sessionKey = GetSessionKey<T>();

            HttpContext.Current.Session[sessionKey] = o;
        }

        public static T Get<T>() where T : class
        {
            AssertSessionAvailable();

            string sessionKey = GetSessionKey<T>();

            T objectFromSession = HttpContext.Current.Session[sessionKey] as T;

            return objectFromSession;
        }

        private static void AssertSessionAvailable()
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                throw new InvalidOperationException("Session is not available. SessionManager should not be used outside a HttpContext.");
            }
        }

        private static string GetSessionKey<T>()
        {
            Type type = typeof(T);

            return type.Name;
        }
    }
}
