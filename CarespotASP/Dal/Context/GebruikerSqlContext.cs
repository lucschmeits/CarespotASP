using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class GebruikerSqlContext : IGebruiker
    {
        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> returnList = new List<Gebruiker>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    

                }

                return returnList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Gebruiker GetGebruikerById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateGebruiker()
        {
            throw new NotImplementedException();
        }

        public void UpdateGebruiker()
        {
            throw new NotImplementedException();
        }

        public void DeleteGebruikerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}