﻿using CarespotASP.Dal.Interfaces;
using CarespotASP.Enums;
using CarespotASP.Models;
using System;
using System.Collections.Generic;
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
                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

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
                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

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
                    var query = "UPDATE Vrijwilliger SET  VOG = @vog, IsGoedgekeurd = @isgoedgekeurd WHERE GebruikerId = @key ";


                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@key", gebruikerId);
                    cmd.Parameters.AddWithValue("@vog", vogPath);
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
    }
}