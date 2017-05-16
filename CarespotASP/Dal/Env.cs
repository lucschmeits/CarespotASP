using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarespotASP.Dal
{
    static public class Env
    {

        static public string ConnectionString = ConfigurationManager.ConnectionStrings["CarespotConnectionString"].ConnectionString;
    }
}