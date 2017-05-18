using CarespotASP.Dal.Interfaces;
using CarespotASP.Enums;
using CarespotASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarespotASP.Dal.Context
{
    public class BeheerderSqlContext : IBeheerder
    {
        public List<Beheerder> GetAllBeheerders()
        {
            var returnList = new List<Beheerder>();
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.*, Vrijwilliger.VOG, Vrijwilliger.IsGoedgekeurd FROM Vrijwilliger INNER JOIN Gebruiker ON Vrijwilliger.GebruikerId = Gebruiker.Id";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        Beheerder b = new Beheerder(
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

                        returnList.Add(b);
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

        public Beheerder GetBeheerderById(int id)
        {
            Beheerder returnBeheerder = null;
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.* FROM Beheerder INNER JOIN Gebruiker ON Beheerder.GebruikerId = Gebruiker.Id where Id = @key";
                    var cmd = new SqlCommand(query, con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@key", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        returnBeheerder = new Beheerder(
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

                return returnBeheerder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CreateBeheerder(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "INSERT INTO Beheerder (GebruikerId) VALUES (" + id + ")";

                    var cmd = new SqlCommand(query, con);

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

        public void DeleteBeheerderById(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "DELETE FROM Beheerder WHERE GebruikerId = @key";
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
    }
}