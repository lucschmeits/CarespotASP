using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Enums;
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

                    string query = "select * from Gebruiker where Uitschrijfdatum is not null";
                    SqlCommand cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    con.Open();

                    while (reader.Read())
                    {
                        Gebruiker user = new Gebruiker(
                            reader.GetInt32(0),
                            (byte[])reader[1],
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetDateTime(6),
                            Convert.ToBoolean(reader.GetInt32(7)),
                            Convert.ToBoolean(reader.GetInt32(8)),
                            Convert.ToBoolean(reader.GetInt32(9)),
                            reader.GetString(10),
                            reader.GetString(12),
                            reader.GetString(13),
                            reader.GetString(14),
                            reader.GetString(15),
                           (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16))
                            );
                        returnList.Add(user);
                    }

                    con.Close();
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