using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class HulpvraagSqlContext : IHulpvraag
    {
        public void Create(Hulpvraag hulpvraag)
        {
            int hulpvraagid;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "INSERT INTO Hulpvraag (Titel, Omschrijving, OpdrachtDatum, CreatedDatum, Locatie, Urgent, Vervoertype, IsAfgerond, HulpbehoevendeId) VALUES (@Titel, @Omschrijving, @Opdrachtdatum, @Createdatum, @Locatie, @Urgent, @VervoerType, @IsAfgerond, @HulpbehoevendeId);SELECT CAST(scope_identity() AS int);";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@Titel", hulpvraag.Titel);
                    command.Parameters.AddWithValue("@Omschrijving", hulpvraag.Omschrijving);
                    command.Parameters.AddWithValue("@Opdrachtdatum", hulpvraag.OpdrachtDatum.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Createdatum", hulpvraag.CreateDatum);
                    command.Parameters.AddWithValue("@Locatie", hulpvraag.Locatie);
                    command.Parameters.AddWithValue("@Urgent", Convert.ToInt32(hulpvraag.Urgent));
                    command.Parameters.AddWithValue("@Vervoertype", Convert.ToString(hulpvraag.VervoerType));
                    command.Parameters.AddWithValue("@IsAfgerond", 0);
                    command.Parameters.AddWithValue("@HulpbehoevendeId", hulpvraag.Hulpbehoevende.Id);

                    hulpvraagid = (int)command.ExecuteScalar();
                }

                //Voeg de vaardigheden toe in de koppeltabel
                if (hulpvraag.Vaardigheden != null)
                {
                    foreach (var vaardigheid in hulpvraag.Vaardigheden)
                    {
                        VaardigheidSqlContext vsc = new VaardigheidSqlContext();
                        VaardigheidRepository vr = new VaardigheidRepository(vsc);

                        vr.AddVaardigheidToHulpvraag(vaardigheid, hulpvraagid);
                    }
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
                //Vaardigheiden koppelingen verwijderen
                VaardigheidSqlContext vaarcontext = new VaardigheidSqlContext();
                VaardigheidRepository vaarrepo = new VaardigheidRepository(vaarcontext);
                vaarrepo.DeleteAllVaardighedenByHulpvraagId(id);

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
                            reader.GetInt32(0), //Id
                            reader.GetString(1), //Titel
                            reader.GetString(2), //Omschrijving
                            reader.GetDateTime(3), //OpdrachtDatum
                            reader.GetDateTime(4), //CreatedDatum
                            reader.GetString(5), //Locatie
                            Convert.ToBoolean(reader.GetInt32(6)), //Urgent
                            (VervoerType)Enum.Parse(typeof(VervoerType), reader.GetString(7)), //Vervoertype
                            Convert.ToBoolean(reader.GetInt32(8))); //IsAfgerond

                        //Hulpbehoevende ophalen
                        HulpbehoevendeSqlContext hbcontext = new HulpbehoevendeSqlContext();
                        HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hbcontext);

                        hv.Hulpbehoevende = hr.GetHulpbehoevendeById(reader.GetInt32(9));

                        //Vrijwilliger ophalen als deze gezet is
                        if (!reader.IsDBNull(10))
                        {
                            VrijwilligerSqlContext vcontext = new VrijwilligerSqlContext();
                            VrijwilligerRepository vr = new VrijwilligerRepository(vcontext);

                            hv.Vrijwilliger = vr.GetVrijwilligerById(reader.GetInt32(10));
                        }

                        //Vaardigheiden ophalen als deze er zijn
                        VaardigheidSqlContext vaarcontext = new VaardigheidSqlContext();
                        VaardigheidRepository vaarrepo = new VaardigheidRepository(vaarcontext);

                        List<Vaardigheid> vaardighedenlijst = vaarrepo.GetVaardigheidByHulpvraagId(hv.Id);

                        if (vaardighedenlijst.Count > 0)
                        {
                            hv.Vaardigheden = vaardighedenlijst;
                        }

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
                            reader.GetInt32(0), //Id
                            reader.GetString(1), //Titel
                            reader.GetString(2), //Omschrijving
                            reader.GetDateTime(3), //OpdrachtDatum
                            reader.GetDateTime(4), //CreatedDatum
                            reader.GetString(5), //Locatie
                            Convert.ToBoolean(reader.GetInt32(6)), //Urgent
                            (VervoerType)Enum.Parse(typeof(VervoerType), reader.GetString(7)), //Vervoertype
                            Convert.ToBoolean(reader.GetInt32(8))); //IsAfgerond

                        //Hulpbehoevende ophalen
                        HulpbehoevendeSqlContext hbcontext = new HulpbehoevendeSqlContext();
                        HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hbcontext);

                        returnObject.Hulpbehoevende = hr.GetHulpbehoevendeById(reader.GetInt32(9));

                        //Vrijwilliger ophalen als deze gezet is
                        if (!reader.IsDBNull(10))
                        {
                            VrijwilligerSqlContext vcontext = new VrijwilligerSqlContext();
                            VrijwilligerRepository vr = new VrijwilligerRepository(vcontext);

                            returnObject.Vrijwilliger = vr.GetVrijwilligerById(reader.GetInt32(10));
                        }

                        //Vaardigheiden ophalen als deze er zijn
                        VaardigheidSqlContext vaarcontext = new VaardigheidSqlContext();
                        VaardigheidRepository vaarrepo = new VaardigheidRepository(vaarcontext);

                        List<Vaardigheid> vaardighedenlijst = vaarrepo.GetVaardigheidByHulpvraagId(returnObject.Id);

                        if (vaardighedenlijst.Count > 0)
                        {
                            returnObject.Vaardigheden = vaardighedenlijst;
                        }
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
                    var cmdString = "UPDATE Hulpvraag SET Titel = @Titel, Omschrijving = @Omschrijving, Opdrachtdatum = @Opdrachtdatum, Locatie = @Locatie, Urgent = @Urgent, Vervoertype = @Vervoertype, IsAfgerond = @IsAfgerond WHERE Id = @id";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@Titel", hulpvraag.Titel);
                    command.Parameters.AddWithValue("@Omschrijving", hulpvraag.Omschrijving);
                    command.Parameters.AddWithValue("@Opdrachtdatum", hulpvraag.OpdrachtDatum.ToString("yyyy-MM-dd"));
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