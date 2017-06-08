using CarespotASP.Dal.Interfaces;
using CarespotASP.Enums;
using CarespotASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CarespotASP.Dal.Context
{
    public class VrijwilligerSqlContext : IVrijwilliger
    {
        public List<Vrijwilliger> GetAllVrijwilligers()
        {
            var returnList = new List<Vrijwilliger>();
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.*, Vrijwilliger.* FROM Vrijwilliger INNER JOIN Gebruiker ON Vrijwilliger.GebruikerId = Gebruiker.Id";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var foto = "";

                        if (!reader.IsDBNull(1))
                        {
                            foto = reader.GetString(1);
                        }

                        Vrijwilliger v = new Vrijwilliger(
                            reader.GetInt32(0),//id
                            foto,//foto
                            reader.GetString(2),//Email
                            reader.GetString(3),//wachtwoord
                            reader.GetString(4),//gebruikersnaam
                            reader.GetString(5),//naam
                            reader.GetDateTime(6),//geboortedatum
                            Convert.ToBoolean(reader.GetInt32(7)),//heeftrijbewijs
                            Convert.ToBoolean(reader.GetInt32(8)),//heeftov
                            Convert.ToBoolean(reader.GetInt32(9)),//heeftauto
                            reader.GetString(10),//telefoon
                                                 //Uitschrijfdatum
                            reader.GetString(12),//adres
                            reader.GetString(13),//woonplaats
                            reader.GetString(14),//land
                            reader.GetString(15),//postcode
                             (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)),//geslacht
                             reader.GetString(17),//barcode
                             reader.GetString(19),//vog
                             Convert.ToBoolean(reader.GetInt32(20)));//isgoedgekeurd
                        v.Vaardigheden = GetVraadigheidByVrijwilligerId(reader.GetInt32(0));
                        returnList.Add(v);
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

        public Vrijwilliger GetVrijwilligerById(int id)
        {
            Vrijwilliger returnVrijwilliger = null;
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.*, Vrijwilliger.* FROM Vrijwilliger INNER JOIN Gebruiker ON Vrijwilliger.GebruikerId = Gebruiker.Id WHERE Vrijwilliger.GebruikerId = @key";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@key", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var foto = "";

                        if (!reader.IsDBNull(1))
                        {
                            foto = reader.GetString(1);
                        }
                        returnVrijwilliger = new Vrijwilliger(
                            reader.GetInt32(0),//id
                            foto,//foto
                            reader.GetString(2),//Email
                            reader.GetString(3),//wachtwoord
                            reader.GetString(4),//gebruikersnaam
                            reader.GetString(5),//naam
                            reader.GetDateTime(6),//geboortedatum
                            Convert.ToBoolean(reader.GetInt32(7)),//heeftrijbewijs
                            Convert.ToBoolean(reader.GetInt32(8)),//heeftov
                            Convert.ToBoolean(reader.GetInt32(9)),//heeftauto
                            reader.GetString(10),//telefoon
                                                 //Uitschrijfdatum
                            reader.GetString(12),//adres
                            reader.GetString(13),//woonplaats
                            reader.GetString(14),//land
                            reader.GetString(15),//postcode
                             (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)),//geslacht
                             reader.GetString(17),//barcode
                             reader.GetString(19),//vog
                             Convert.ToBoolean(reader.GetInt32(20)));//isgoedgekeurd
                        returnVrijwilliger.Vaardigheden = GetVraadigheidByVrijwilligerId(reader.GetInt32(0));
                    }

                    con.Close();
                }

                return returnVrijwilliger;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CreateVrijwilliger(int gebruikerId, string vogPath)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "INSERT INTO Vrijwilliger (GebruikerId, VOG, IsGoedgekeurd) VALUES (@GebruikerId, @vog, @isGoedgekeurd)";

                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@GebruikerId", gebruikerId);
                    cmd.Parameters.AddWithValue("@vog", vogPath);
                    cmd.Parameters.AddWithValue("@IsGoedgekeurd", 0);

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

        public void UpdateVrijwilliger(int gebruikerId, string vogPath, bool isGoedgekeurd)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "UPDATE Vrijwilliger SET IsGoedgekeurd = @isgoedgekeurd WHERE GebruikerId = @key ";


                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@key", gebruikerId);
                    //cmd.Parameters.AddWithValue("@vog", vogPath);
                    cmd.Parameters.AddWithValue("@IsGoedgekeurd", Convert.ToInt32(isGoedgekeurd));
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

        public void DeleteVrijwilligerById(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "DELETE FROM Vrijwilliger WHERE GebruikerId = @key";
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

        public List<Vaardigheid> GetVraadigheidByVrijwilligerId(int id)
        {
            var returnList = new List<Vaardigheid>();
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var query = "SELECT Vaardigheid.* FROM Vaardigheid INNER JOIN Vrijwilliger_Vaardigheid ON Vaardigheid.Id = Vrijwilliger_Vaardigheid.VaardigheidId INNER JOIN Vrijwilliger ON Vrijwilliger_Vaardigheid.VrijwilligerId = Vrijwilliger.GebruikerId AND Vrijwilliger_Vaardigheid.VrijwilligerId = Vrijwilliger.GebruikerId WHERE Vrijwilliger.GebruikerId = @id ";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {


                        var vaardigheid = new Vaardigheid(
                            reader.GetInt32(0), reader.GetString(1));

                        returnList.Add(vaardigheid);
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

        public void CreateVrijwilligerWithVaardigheid(int vrijwilligerId, List<int> vaardigheidList)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var query = "DELETE FROM Vrijwilliger_Vaardigheid WHERE VrijwilligerId = @id";
                    var cmd1 = new SqlCommand(query, con);
                    cmd1.Parameters.AddWithValue("@id", vrijwilligerId);
                    cmd1.ExecuteNonQuery();

                    DataTable tvp = new DataTable();
                    tvp.Columns.Add("VrijwilligerId", typeof(int));
                    tvp.Columns.Add("VaardigheidId", typeof(int));

                    foreach (var id in vaardigheidList)
                    {
                        tvp.Rows.Add(vrijwilligerId, id);
                    }
                    SqlCommand cmd = new SqlCommand("dbo.Vaardigheden", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter tvparam = cmd.Parameters.AddWithValue("@List", tvp);
                    tvparam.SqlDbType = SqlDbType.Structured;

                    // execute query, consume results, etc. here
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