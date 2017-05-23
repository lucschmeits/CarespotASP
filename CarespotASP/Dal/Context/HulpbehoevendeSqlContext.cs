using System;
using System.Collections.Generic;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;
using System.Data.SqlClient;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;

namespace CarespotASP.Dal.Context
{
    public class HulpbehoevendeSqlContext : IHulpbehoevende
    {
        public void CreateHulpbehoevende(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "INSERT INTO Hulpbehoevende (GebruikerId) VALUES (" + id + ")";

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

        public void DeleteHulpbehoevendeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Hulpbehoevende> GetAllHulpbehoevenden()
        {
            List<Hulpbehoevende> returnList = new List<Hulpbehoevende>();
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.*, Hulpbehoevende.HulpverlenerId FROM Hulpbehoevende INNER JOIN Gebruiker ON Hulpbehoevende.GebruikerId = Gebruiker.Id";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        //Haal hulpverlener op aan hand van id.
                        var sql = new HulpverlenerSqlContext();
                        var repo = new HulpverlenerRepository(sql);
                        var hulpverlener = repo.GetById(reader.GetInt32(18));

                        var hv = new Hulpbehoevende(
                            reader.GetInt32(0),
                            foto,
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetDateTime(6),
                            reader.GetBoolean(7),
                            reader.GetBoolean(8),
                            reader.GetBoolean(9),
                            reader.GetString(10),
                            reader.GetString(11),
                            reader.GetString(12),
                            reader.GetString(13),
                            reader.GetString(14),
                            (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)),
                            hulpverlener
                        );

                        returnList.Add(hv);
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

        public Hulpbehoevende GetHulpbehoevendeById(int id)
        {
            Hulpbehoevende returnHulpbehoevende = null;
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT Gebruiker.*, Hulpbehoevende.HulpverlenerId FROM Hulpbehoevende INNER JOIN Gebruiker ON Hulpbehoevende.GebruikerId = Gebruiker.Id where Id = @key";
                    var cmd = new SqlCommand(query, con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@key", id);
                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        //Vul foto als deze niet leeg is
                        var foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        //Haal hulpverlener op aan hand van id.
                        var sql = new HulpverlenerSqlContext();
                        var repo = new HulpverlenerRepository(sql);
                        var hulpverlener = repo.GetById(reader.GetInt32(18));

                        returnHulpbehoevende = new Hulpbehoevende(
                            reader.GetInt32(0), //id
                            foto,  //foto
                            reader.GetString(2), //Email
                            reader.GetString(3), //wachtwoord
                            reader.GetString(4), //Gebruikernaam
                            reader.GetString(5), //Naam
                            reader.GetDateTime(6), //Geboortedatum
                            Convert.ToBoolean(reader.GetInt32(7)), //Heeft Rijbewijs
                            Convert.ToBoolean(reader.GetInt32(8)), //Heeft OV
                            Convert.ToBoolean(reader.GetInt32(9)), //Heeft Auto
                            reader.GetString(10), //Telefoonnummer
                            reader.GetString(12), //Adres
                            reader.GetString(13), //Woonplaats
                            reader.GetString(14), //Land
                            reader.GetString(15), //Postcode
                            (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)), //Geslacht
                            hulpverlener //Hulpverlener
                            );

                        //Barcode
                        if (!reader.IsDBNull(17))
                        {
                            returnHulpbehoevende.Barcode = reader.GetString(17);
                        }

                        //Uitschrijfdatum
                        if (!reader.IsDBNull(10))
                        {
                            returnHulpbehoevende.Uitschrijfdatum = reader.GetDateTime(11); //Uitschrijfdatum
                        }
                    }
                    con.Close();
                }

                return returnHulpbehoevende;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateHulpbehoevende(int id, Hulpbehoevende hulpbehoevende)
        {
            throw new NotImplementedException();
        }
    }
}