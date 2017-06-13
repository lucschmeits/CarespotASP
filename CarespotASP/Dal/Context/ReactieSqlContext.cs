using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class ReactieSqlContext : IReactie
    {
        public void AcceptHulpvraag(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "UPDATE Hulpvraag SET VrijwilligerId = (SELECT VrijwilligerId FROM Reactie WHERE Id = @id ) WHERE Id = (SELECT HulpvraagId FROM Reactie WHERE Id = @id ); DELETE FROM Reactie WHERE Id = @id; ";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
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

        public int CreateReactie(Reactie reactie)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Reactie(Bericht, Datum, VrijwilligerId, HulpvraagId) VALUES(@bericht, @datum, @vrijwilligerid, @hulpvraagid);  SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@bericht", reactie.Bericht);
                    cmd.Parameters.AddWithValue("@datum", reactie.Datum);
                    cmd.Parameters.AddWithValue("@vrijwilligerid", reactie.VrijwilligerId);
                    cmd.Parameters.AddWithValue("@hulpvraagid", reactie.HulpvraagId);

                    returnId = (int)cmd.ExecuteScalar();

                    con.Close();
                }

                HulpvraagRepository hr = new HulpvraagRepository(new HulpvraagSqlContext());
                Hulpvraag hulpvraag = hr.GetById(reactie.HulpvraagId);

                using (MailMessage mm = new MailMessage("info.carespot@gmail.com", hulpvraag.Hulpbehoevende.Email))
                {
                    mm.Subject = "Nieuwe reactie op hulpvraag";
                    string body = "Hallo " + hulpvraag.Hulpbehoevende.Naam + ",";
                    body += "<br /><br />U heeft een reactie ontvangen op uw hulpvraag:";
                    body += "<br /><br />" + reactie.Bericht;
                    body += "<br /><br />Met vriendelijke groeten,";
                    body += "<br /><br />Team Carespot";
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("info.carespot@gmail.com", "Carespot1234");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }

                return returnId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeclineHulpvraag(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "DELETE FROM Reactie WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
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

        public void DeleteReactieById(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "DELETE FROM Reactie WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
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

        public List<Reactie> GetAllReacties()
        {
            List<Reactie> returnList = new List<Reactie>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "SELECT * FROM Reactie";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Reactie reactie = new Reactie(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDateTime(2),
                            reader.GetInt32(3),
                            reader.GetInt32(4)
                        );
                        returnList.Add(reactie);
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

        public Reactie GetReactieById(int id)
        {
            Reactie returnReactie = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "SELECT * FROM Reactie WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        returnReactie = new Reactie(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDateTime(2),
                            reader.GetInt32(3),
                            reader.GetInt32(4)
                        );
                    con.Close();
                }
                return returnReactie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}