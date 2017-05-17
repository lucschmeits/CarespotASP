using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class ReviewSqlContext : IReview
    {
        public List<Review> GetAllReviews()
        {
            var returnList = new List<Review>();
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT * FROM Review";
                    var cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var review = new Review(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                        );
                        returnList.Add(review);
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

        public Review GetReviewById(int id)
        {
            Review returnReview = null;
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "SELECT * FROM Review WHERE Id = @id";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                        returnReview = new Review(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                        );
                    con.Close();
                }
                return returnReview;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int CreateReview(Review review)
        {
            var returnId = 0;
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "INSERT INTO Review(AuteurId, GebruikerId, Omschrijving, Beoordeling) VALUES(@auteurid, @gebruikerid, @omschrijving, @beoordeling";
                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@auteurid", review.AuteurId);
                    cmd.Parameters.AddWithValue("@gebruikerid", review.GebruikerId);
                    cmd.Parameters.AddWithValue("@omschrijving", review.Omschrijving);
                    cmd.Parameters.AddWithValue("@beoordeling", review.Beoordeling);

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

        public void UpdateReview(Review review)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "UPDATE Review SET AuteurId = @auteurid, GebruikerId = @gebruikerid, Omschrijving = @omschrijving, Beoordeling = @beoordeling WHERE id = @id";
                    var cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@auteurid", review.AuteurId);
                    cmd.Parameters.AddWithValue("@gebruikerid", review.GebruikerId);
                    cmd.Parameters.AddWithValue("@omschrijving", review.Omschrijving);
                    cmd.Parameters.AddWithValue("@beoordeling", review.Beoordeling);

                    cmd.Parameters.AddWithValue("@id", review.Id);

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

        public void DeleteReviewById(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    var query = "DELETE FROM Review WHERE id = @id";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
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