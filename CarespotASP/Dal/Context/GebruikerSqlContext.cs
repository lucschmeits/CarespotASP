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
    public class GebruikerSqlContext : IGebruiker
    {
        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> returnList = new List<Gebruiker>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "select * from Gebruiker where Uitschrijfdatum is not null";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //Standaard foto
                        byte[] foto = new byte[10];

                        if (!reader.IsDBNull(1))
                        {
                            foto = (byte[])reader[1];
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
                           (Geslacht)Enum.Parse(typeof(Geslacht), reader.GetString(16))
                            );
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
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //Standaard foto
                        byte[] foto = new byte[10];

                        if (!reader.IsDBNull(1))
                        {
                            foto = (byte[])reader[1];
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

                        user.Uitschrijfdatum = reader.GetDateTime(11);
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
                    string query = "INSERT INTO Gebruiker(Foto, Email, Wachtwoord, Gebruikersnaam, Naam, Geboortedatum, HeeftRijbewijs, HeeftOv, HeeftAuto, Telefoonnummer, Uitschrijfdatum, Adres, Woonplaats, Land, Postcode, Geslacht)VALUES" +
                    "(@foto,@email,@wachtwoord,@gebruikersnaam,@naam,@geboortedatum,@heeftRijbewijs,@heeftOv,@heeftAuto,@telefoonnummer,@uitschrijfdatum,@adres,@woonplaats,@land,@postcode,@geslacht);SELECT CAST(scope_identity() AS int);";
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
                    cmd.Parameters.AddWithValue("@uitschrijfdatum", obj.Uitschrijfdatum.ToString());
                    cmd.Parameters.AddWithValue("@adres", obj.Adres);
                    cmd.Parameters.AddWithValue("@woonplaats", obj.Woonplaats);
                    cmd.Parameters.AddWithValue("@land", obj.Land);
                    cmd.Parameters.AddWithValue("@postcode", obj.Postcode);
                    cmd.Parameters.AddWithValue("@geslacht", obj.Geslacht.ToString());

                    returnId = (int)cmd.ExecuteScalar();

                    cmd.ExecuteNonQuery();
                    con.Close();
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
                    string query = "UPDATE Gebruiker SET Foto = @foto, Email = @email, Wachtwoord = @wachtwoord, Gebruikersnaam = @gebruikersnaam, Naam = @naam, Geboortedatum = @geboortedatum, HeeftRijbewijs = @heeftRijbewijs, HeeftOv = @heeftOv, HeeftAuto = @heeftAuto, Telefoonnummer = @telefoonnummer, Uitschrijfdatum = @uitschrijfdatum, Adres = @adres, Woonplaats = @woonplaats, Land = @land, Postcode =@postcode" +
                                   ", Geslacht = @geslacht WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@foto", obj.Image);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@wachtwoord", obj.Wachtwoord);
                    cmd.Parameters.AddWithValue("@gebruikersnaam", obj.Gebruikersnaam);
                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    cmd.Parameters.AddWithValue("@geboortedatum", obj.Geboortedatum);
                    cmd.Parameters.AddWithValue("@heeftRijbewijs", Convert.ToInt32(obj.HeeftRijbewijs));
                    cmd.Parameters.AddWithValue("@heeftOv", Convert.ToInt32(obj.HeeftOv));
                    cmd.Parameters.AddWithValue("@heeftAuto", Convert.ToInt32(obj.HeeftAuto));
                    cmd.Parameters.AddWithValue("@telefoonnummer", obj.Telefoonnummer);
                    cmd.Parameters.AddWithValue("@uitschrijfdatum", obj.Uitschrijfdatum);
                    cmd.Parameters.AddWithValue("@adres", obj.Adres);
                    cmd.Parameters.AddWithValue("@woonplaats", obj.Woonplaats);
                    cmd.Parameters.AddWithValue("@land", obj.Land);
                    cmd.Parameters.AddWithValue("@postcode", obj.Postcode);
                    cmd.Parameters.AddWithValue("@geslacht", obj.Geslacht.ToString());

                    cmd.Parameters.AddWithValue("@key", obj.Id);
                    var reader = cmd.ExecuteNonQuery();
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
                    string query = "DELETE FROM Gebruiker WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);
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