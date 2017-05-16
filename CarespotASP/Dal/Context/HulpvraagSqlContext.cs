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
    public class HulpvraagSqlContext : IHulpvraag
    {
        public void Create(Hulpvraag hulpvraag)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Hulpvraag> GetAll()
        {
            List<Hulpvraag> returnList = new List<Hulpvraag>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "SELECT * FROM Hulpvraag";
                    var command = new SqlCommand(cmdString, con);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Hulpvraag hv = new Hulpvraag(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDateTime(3),
                            reader.GetDateTime(4),
                            reader.GetString(5),
                            reader.GetBoolean(6),
                            (VervoerType)Enum.Parse(typeof(VervoerType), reader.GetString(7)),
                            reader.GetBoolean(8));

                        returnList.Add(hv);
                    }
                    con.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return returnList;
        }
    
        public Hulpvraag GetById(int id)
        {
            Hulpvraag returnObject = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "SELECT * FROM Hulpvraag";
                    var command = new SqlCommand(cmdString, con);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        returnObject = new Hulpvraag(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDateTime(3),
                            reader.GetDateTime(4),
                            reader.GetString(5),
                            reader.GetBoolean(6),
                            (VervoerType)Enum.Parse(typeof(VervoerType), reader.GetString(7)),
                            reader.GetBoolean(8));
                }
                    con.Close();
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return returnObject;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}