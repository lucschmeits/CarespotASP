using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarespotASP.Models;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Enums;


namespace CarespotASP.Dal.Context
{
    public class BeschikbaarheidSqlContext : IBeschikbaarheid
    {
        public int CreateBeschikbaarheid(Beschikbaarheid obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Beschikbaarheid(DagNaam, DagDeel)VALUES" + "(@dagnaam, @dagdeel); SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@dagnaam", obj.DagNaam);
                    cmd.Parameters.AddWithValue("@dagdeel", obj.DagDeel);

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

        public void DeleteBeschikbaarheid(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Beschikbaarheid WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@key", Id);
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

        public List<Beschikbaarheid> GetAllBeschikbaarheid()
        {
            List<Beschikbaarheid> returnList = new List<Beschikbaarheid>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    string query = "select * from Beschikbaarheid";
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    var reader = cmd.ExecuteReader();
                  
                    while (reader.Read())
                    {
                        Beschikbaarheid b = new Beschikbaarheid(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                            );
                        returnList.Add(b);
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

        public Beschikbaarheid GetBeschikbaarheidById(int Id)
        {
            Beschikbaarheid returnBeschikbaarheid = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    string query = "select * from Beschikbaarheid where Id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", Id);
                    
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Beschikbaarheid beschikbaarheid = new Beschikbaarheid(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                            );
                        returnBeschikbaarheid = beschikbaarheid;
                    }

                    con.Close();
                }

                return returnBeschikbaarheid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void UpdateBeschikbaarheid(Beschikbaarheid obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    string query = "UPDATE Beschikbaarheid SET DagNaam = @dagnaam, DagDeel = @dagdeel WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@dagnaam", obj.DagNaam);
                    cmd.Parameters.AddWithValue("@dagdeel", obj.DagDeel);

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

        public List<Beschikbaarheid> GetBeschikbaarheidByVrijwilligerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}