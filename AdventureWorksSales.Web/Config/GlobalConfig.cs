using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Config
{
    public class GlobalConfig
    {
        public static string CnnString()
        {
            return ConfigurationManager.ConnectionStrings["WorksSales"].ConnectionString;
        }
    }
}