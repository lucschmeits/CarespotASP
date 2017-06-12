using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CarespotASP.Models;
using CarespotASP.Dal.Interfaces;

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
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Reactie(Bericht, Datum, VrijwilligerId, HulpvraagId) VALUES(@bericht, @datum, @vrijwilligerid, @hulpvraagid);  SELECT CAST(scope_identity() AS int);";
                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@bericht", reactie.Bericht);
                    cmd.Parameters.AddWithValue("@datum", reactie.Datum);
                    cmd.Parameters.AddWithValue("@vrijwilligerid", reactie.VrijwilligerId);
                    cmd.Parameters.AddWithValue("@hulpvraagid", reactie.HulpvraagId);

                    returnId = (int)cmd.ExecuteScalar();

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

        public void DeclineHulpvraag(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteReactieById(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "DELETE FROM Reactie WHERE id = @id";
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

        public List<Reactie> GetAllReacties()
        {
            var returnList = new List<Reactie>();
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "SELECT * FROM Reactie";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var reactie = new Reactie(
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
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    string query = "SELECT * FROM Reactie WHERE Id = @id";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    var reader = cmd.ExecuteReader();

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