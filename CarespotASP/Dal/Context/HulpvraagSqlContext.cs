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
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "INSERT INTO Hulpvraag (Titel, Omschrijving, OpdrachtDatum, CreatedDatum, Locatie, Urgent, Vervoertype, IsAfgerond, HulpbehoevendeId,VrijwilligerId) VALUES (@Titel, @Omschrijving, @Opdrachtdatum, @Createdatum, @Locatie, @Urgent, @VervoerType, @IsAfgerond, @HulpbehoevendeId, @VrijwilligerID);";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@Titel", hulpvraag.Titel);
                    command.Parameters.AddWithValue("@Omschrijving", hulpvraag.Omschrijving);
                    command.Parameters.AddWithValue("@Opdrachtdatum", hulpvraag.OpdrachtDatum.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Createdatum", hulpvraag.OpdrachtDatum.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Locatie", hulpvraag.Locatie);
                    command.Parameters.AddWithValue("@Urgent", Convert.ToInt32(hulpvraag.Urgent));
                    command.Parameters.AddWithValue("@Vervoertype", Convert.ToString(hulpvraag.VervoerType));
                    command.Parameters.AddWithValue("@IsAfgerond", Convert.ToInt32(hulpvraag.IsAfgerond));
                    command.Parameters.AddWithValue("@HulpbehoevendeId", hulpvraag.Hulpbehoevende.Id);
                    command.Parameters.AddWithValue("@VrijwilligerId", 0);
                    command.ExecuteNonQuery();
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
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "DELETE FROM Hulpvraag WHERE id = @id";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
                    var cmdString = "SELECT * FROM Hulpvraag WHERE Id = @Id";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@Id", id);
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

        public void Update(int id, Hulpvraag hulpvraag)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "UPDATE Hulpvraag SET Titel = @Titel, Omschrijving = @Omschrijving, Opdrachtdatum = @Opdrachtdatum, Createdatum = @Createdatum";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@Titel", hulpvraag.Titel);
                    command.Parameters.AddWithValue("@Omschrijving", hulpvraag.Omschrijving);
                    command.Parameters.AddWithValue("@Opdrachtdatum", hulpvraag.OpdrachtDatum.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Createdatum", hulpvraag.OpdrachtDatum.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Locatie", hulpvraag.Locatie);
                    command.Parameters.AddWithValue("@Urgent", Convert.ToInt32(hulpvraag.Urgent));
                    command.Parameters.AddWithValue("@Vervoertype", Convert.ToString(hulpvraag.VervoerType));
                    command.Parameters.AddWithValue("@IsAfgerond", Convert.ToInt32(hulpvraag.IsAfgerond));
                    command.ExecuteNonQuery();
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