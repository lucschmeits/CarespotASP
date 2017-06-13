using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
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
                    string query = "select * from Gebruiker where Uitschrijfdatum is null";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string foto = "";

                        if (!reader.IsDBNull(1))
                        {
                            foto = reader.GetString(1);
                        }

                        Gebruiker user = new Gebruiker(
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

                        if (!reader.IsDBNull(17))
                        {
                            user.Barcode = reader.GetString(17);
                        }

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
            Gebruiker returnUser = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "select * from Gebruiker where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //Standaard foto
                        string foto = "";

                        if (!reader.IsDBNull(1))
                        {
                            foto = reader.GetString(1);
                        }

                        Gebruiker user = new Gebruiker(
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

                        if (!reader.IsDBNull(17))
                        {
                            user.Barcode = reader.GetString(17);
                        }

                        if (!reader.IsDBNull(11))
                        {
                            user.Uitschrijfdatum = reader.GetDateTime(11);
                        }

                        returnUser = user;
                    }

                    con.Close();
                }

                return returnUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int CreateGebruiker(Gebruiker obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "INSERT INTO Gebruiker(Foto, Email, Wachtwoord, Gebruikersnaam, Naam, Geboortedatum, HeeftRijbewijs, HeeftOv, HeeftAuto, Telefoonnummer, Adres, Woonplaats, Land, Postcode, Geslacht, Barcode)VALUES" +
                                   "(@foto,@email,@wachtwoord,@gebruikersnaam,@naam,@geboortedatum,@heeftRijbewijs,@heeftOv,@heeftAuto,@telefoonnummer,@adres,@woonplaats,@land,@postcode,@geslacht,@barcode);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@foto", obj.Image);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@wachtwoord", obj.Wachtwoord);
                    cmd.Parameters.AddWithValue("@gebruikersnaam", obj.Gebruikersnaam);
                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    cmd.Parameters.AddWithValue("@geboortedatum", obj.Geboortedatum.ToString());
                    cmd.Parameters.AddWithValue("@heeftRijbewijs", Convert.ToInt32(obj.HeeftRijbewijs));
                    cmd.Parameters.AddWithValue("@heeftOv", Convert.ToInt32(obj.HeeftOv));
                    cmd.Parameters.AddWithValue("@heeftAuto", Convert.ToInt32(obj.HeeftAuto));
                    cmd.Parameters.AddWithValue("@telefoonnummer", obj.Telefoonnummer);
                    //cmd.Parameters.AddWithValue("@uitschrijfdatum", obj.Uitschrijfdatum.ToString());
                    cmd.Parameters.AddWithValue("@adres", obj.Adres);
                    cmd.Parameters.AddWithValue("@woonplaats", obj.Woonplaats);
                    cmd.Parameters.AddWithValue("@land", obj.Land);
                    cmd.Parameters.AddWithValue("@postcode", obj.Postcode);
                    cmd.Parameters.AddWithValue("@geslacht", obj.Geslacht.ToString());
                    cmd.Parameters.AddWithValue("@barcode", obj.Barcode);

                    returnId = (int)cmd.ExecuteScalar();

                    //cmd.ExecuteNonQuery();
                    con.Close();
                }

                using (MailMessage mm = new MailMessage("info.carespot@gmail.com", obj.Email))
                {
                    mm.Subject = "Account aangemaakt";
                    string body = "Hallo " + obj.Naam + ",";
                    body += "<br /><br />U heeft zojuist een nieuw account aangemaakt met dit e-mailadres";
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

        public void UpdateGebruiker(Gebruiker obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "UPDATE Gebruiker SET Foto = @foto, Email = @email, Wachtwoord = @wachtwoord, Gebruikersnaam = @gebruikersnaam, Naam = @naam, HeeftRijbewijs = @heeftRijbewijs, HeeftOv = @heeftOv, HeeftAuto = @heeftAuto, Telefoonnummer = @telefoonnummer, Uitschrijfdatum = @uitschrijfdatum, Adres = @adres, Woonplaats = @woonplaats, Land = @land, Postcode =@postcode" +
                                   ", Geslacht = @geslacht, Barcode = @barcode WHERE id = @key";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@foto", obj.Image);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@wachtwoord", obj.Wachtwoord);
                    cmd.Parameters.AddWithValue("@gebruikersnaam", obj.Gebruikersnaam);
                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    //cmd.Parameters.AddWithValue("@geboortedatum", obj.Geboortedatum);
                    cmd.Parameters.AddWithValue("@heeftRijbewijs", Convert.ToInt32(obj.HeeftRijbewijs));
                    cmd.Parameters.AddWithValue("@heeftOv", Convert.ToInt32(obj.HeeftOv));
                    cmd.Parameters.AddWithValue("@heeftAuto", Convert.ToInt32(obj.HeeftAuto));
                    cmd.Parameters.AddWithValue("@telefoonnummer", obj.Telefoonnummer);
                    if (obj.Uitschrijfdatum == DateTime.Parse("1-1-0001 00:00:00"))
                    {
                        cmd.Parameters.AddWithValue("@uitschrijfdatum", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@uitschrijfdatum", obj.Uitschrijfdatum);
                    }

                    cmd.Parameters.AddWithValue("@adres", obj.Adres);
                    cmd.Parameters.AddWithValue("@woonplaats", obj.Woonplaats);
                    cmd.Parameters.AddWithValue("@land", obj.Land);
                    cmd.Parameters.AddWithValue("@postcode", obj.Postcode);
                    cmd.Parameters.AddWithValue("@geslacht", obj.Geslacht.ToString());
                    if (obj.Barcode == null)
                    {
                        cmd.Parameters.AddWithValue("@barcode", DBNull.Value);
                }
                    else
                    {
                    cmd.Parameters.AddWithValue("@barcode", obj.Barcode);
                }
                  

                    cmd.Parameters.AddWithValue("@key", obj.Id);
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

        public void DeleteGebruikerById(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "UPDATE Gebruiker SET Uitschrijfdatum = @date WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
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