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
    public class VaardigheidSqlContext :IVaardigheid
    {
        public List<Vaardigheid> GetAllVaardigheden()
        {
            List<Vaardigheid> returnList = new List<Vaardigheid>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {

                    string query = "select * from Vaardigheid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Vaardigheid vaardigheid = new Vaardigheid(
                            reader.GetInt32(0),
                            reader.GetString(1));
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

        public Vaardigheid GetVaardigheidById(int id)
        {
            Vaardigheid returnVaardigheid = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {

                    string query = "select * from Vaardigheid where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Vaardigheid vaardigheid = new Vaardigheid(
                            reader.GetInt32(0),
                            reader.GetString(1));
                        returnVaardigheid = vaardigheid;
                    }

                    con.Close();
                }

                return returnVaardigheid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int CreateVaardigheid(Vaardigheid obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {

                    string query = "INSERT INTO Vaardigheid(Omschrijving)VALUES" +
                    "(@omschrijving);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    cmd.Parameters.AddWithValue("@omschrijving", obj.Omschrijving);

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

        public void UpdateVaardigheid(Vaardigheid obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {

                    string query = "UPDATE Vaardigheid SET Omschrijving = @omschrijving WHERE id = @key";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@omschrijving", obj.Omschrijving);

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

        public void DeleteVaardigheidById(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "DELETE FROM Vaardigheid WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
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

        public List<Vaardigheid> GetVaardigheidByVrijwilligerId(int id)
        {


            List<Vaardigheid> returnList = new List<Vaardigheid>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {

                    string query = "SELECT Vaardigheid.Id, Vaardigheid.Omschrijving FROM Vrijwilliger_Vaardigheid INNER JOIN Vaardigheid ON Vrijwilliger_Vaardigheid.VaardigheidId = Vaardigheid.Id WHERE Vrijwilliger_Vaardigheid.VrijwilligerId = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);

                    con.Open();
                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Vaardigheid vaardigheid = new Vaardigheid(
                            reader.GetInt32(0),
                            reader.GetString(1));
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

        public List<Vaardigheid> GetVaardigheidByHulpvraagId(int id)
        {
           // NOT TESTED
            List<Vaardigheid> returnList = new List<Vaardigheid>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {

                    string query = "SELECT Vaardigheid.Id, Vaardigheid.Omschrijving FROM Vaardigheid INNER JOIN Hulpvraag_Vaardigheid ON Vaardigheid.Id = Hulpvraag_Vaardigheid.VaardigheidId WHERE Hulpvraag_Vaardigheid.HulpvraagId = @key ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);

                    con.Open();
                    var reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        Vaardigheid vaardigheid = new Vaardigheid(
                            reader.GetInt32(0),
                            reader.GetString(1));
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
    }
}