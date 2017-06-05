﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class HulpbehoevendeSqlContext : IHulpbehoevende
    {
        public void CreateHulpbehoevende(int id)
        {
            //Maak aan doormiddel van gebruiker repo
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "INSERT INTO Hulpbehoevende (GebruikerId) VALUES (" + id + ")";

                    SqlCommand cmd = new SqlCommand(query, con);

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
            //Delete rol van gebruiker
            throw new NotImplementedException();
        }

        public List<Hulpbehoevende> GetAllHulpbehoevenden()
        {
            List<Hulpbehoevende> returnList = new List<Hulpbehoevende>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "SELECT Gebruiker.*, Hulpbehoevende.HulpverlenerId FROM Hulpbehoevende INNER JOIN Gebruiker ON Hulpbehoevende.GebruikerId = Gebruiker.Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        byte[] foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        HulpverlenerSqlContext sql = new HulpverlenerSqlContext();
                        HulpverlenerRepository repo = new HulpverlenerRepository(sql);

                        Hulpverlener hulpverlener = repo.GetById(reader.GetInt32(18));

                        Hulpbehoevende hv = new Hulpbehoevende(
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
                            (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)),
                            hulpverlener
                        );

                        //Barcode
                        if (!reader.IsDBNull(17))
                            hv.Barcode = reader.GetString(17);

                        //Uitschrijfdatum
                        if (!reader.IsDBNull(11))
                            hv.Uitschrijfdatum = reader.GetDateTime(11);

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
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "SELECT Gebruiker.*, Hulpbehoevende.HulpverlenerId FROM Hulpbehoevende INNER JOIN Gebruiker ON Hulpbehoevende.GebruikerId = Gebruiker.Id where Id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@key", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        byte[] foto = new byte[10];
                        if (!reader.IsDBNull(1))
                            foto = (byte[])reader[1];

                        HulpverlenerSqlContext sql = new HulpverlenerSqlContext();
                        HulpverlenerRepository repo = new HulpverlenerRepository(sql);

                        Hulpverlener hulpverlener = repo.GetById(reader.GetInt32(18));

                        returnHulpbehoevende = new Hulpbehoevende(
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
                            (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16)),
                            hulpverlener
                        );
                        //Barcode
                        if (!reader.IsDBNull(17))
                            returnHulpbehoevende.Barcode = reader.GetString(17);

                        //Uitschrijfdatum
                        if (!reader.IsDBNull(11))
                            returnHulpbehoevende.Uitschrijfdatum = reader.GetDateTime(11);
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