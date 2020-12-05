using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcerciseOne.WebApp
{
    public class Configuration
    {
        public static string WebApiUrl { get { return System.Configuration.ConfigurationManager.AppSettings.Get("WebApiUrl"); } }
#if DEBUG
        public static bool IsDebug { get { return true; } }
#else
        public static bool IsDebug { get { return false; } }
#endif
    }
}