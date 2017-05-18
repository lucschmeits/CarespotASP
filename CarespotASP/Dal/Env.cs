using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarespotASP.Dal
{
    public static class Env
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["CarespotConnectionString"].ConnectionString;
    }
}