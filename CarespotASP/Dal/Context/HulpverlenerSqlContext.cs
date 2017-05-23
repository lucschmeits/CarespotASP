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
    public class HulpverlenerSqlContext : IHulpverlener
    {
        public void Create(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "INSERT INTO Hulpverlener (GebruikerId) VALUES (@key)";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "DELETE FROM Hulpverlener WHERE GebruikerId = @key";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Hulpverlener> GetAll()
        {
            var returnList = new List<Hulpverlener>();
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.* FROM Gebruiker INNER JOIN Hulpverlener ON Gebruiker.Id = Hulpverlener.GebruikerId";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        var h = new Hulpverlener(
                            reader.GetInt32(0),
                            foto,
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
                            (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)));

                        returnList.Add(h);
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

        public Hulpverlener GetById(int id)
        {
            Hulpverlener returnHulpverlener = null;
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.* FROM Gebruiker INNER JOIN Hulpverlener ON Gebruiker.Id = Hulpverlener.GebruikerId WHERE Id = @key";
                    var cmd = new SqlCommand(query, con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@key", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        returnHulpverlener = new Hulpverlener(
                           reader.GetInt32(0),
                           foto,
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
                           (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)));
                    }

                    con.Close();
                }

                return returnHulpverlener;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}