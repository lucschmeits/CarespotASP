using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class ChatSqlContext : IChat
    {
        public void Create(Chat chat)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "INSERT INTO Chatbericht (AuteurId, OntvangerId, DatumTijd, Bericht) VALUES(@auteur, @ontvanger, @datum, @bericht);";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@datum", chat.DatumTijd);
                    command.Parameters.AddWithValue("@bericht", chat.Bericht);
                    command.Parameters.AddWithValue("@auteur", chat.Auteur.Id);
                    command.Parameters.AddWithValue("@ontvanger", chat.Ontvanger.Id);
                    command.ExecuteNonQuery();
                    con.Close();
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
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "DELETE FROM Chatbericht WHERE Id = @id";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Chat> GetAll()
        {
            try
            {
                List<Chat> chats = new List<Chat>();
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "SELECT * FROM Chatbericht";
                    var command = new SqlCommand(cmdString, con);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var gsql = new GebruikerSqlContext();
                        var grepo = new GebruikerRepository(gsql);
                        var g1 = grepo.GetById(reader.GetInt32(1));
                        var g2 = grepo.GetById(reader.GetInt32(2));
                        var chat = new Chat(reader.GetInt32(0), g1, g2, reader.GetDateTime(3), reader.GetString(4));
                        chats.Add(chat);
                    }
                    con.Close();
                    return chats;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Chat GetById(int id)
        {
            try
            {
                using (var con = new SqlConnection(Env.ConnectionString))
                {
                    con.Open();
                    var cmdString = "SELECT * FROM Chatbericht WHERE Id = @id";
                    var command = new SqlCommand(cmdString, con);
                    command.Parameters.AddWithValue("@id", id);
                    var reader = command.ExecuteReader();

                    Chat chat = null;

                    while (reader.Read())
                    {
                        var gsql = new GebruikerSqlContext();
                        var grepo = new GebruikerRepository(gsql);
                        var g1 = grepo.GetById(reader.GetInt32(1));
                        var g2 = grepo.GetById(reader.GetInt32(2));
                        chat = new Chat(reader.GetInt32(0), g1, g2, reader.GetDateTime(3), reader.GetString(4));
                    }
                    con.Close();
                    return chat;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //public void Update(Chat chat)
        //{
        //    try
        //    {
        //        using (var con = new SqlConnection(Env.ConnectionString))
        //        {
        //            con.Open();
        //            var cmdString = "UPDATE Chatbericht SET DatumTijd = @datum, Bericht = @bericht WHERE Id = @id";
        //            var command = new SqlCommand(cmdString, con);
        //            command.Parameters.AddWithValue("@id", chat.Id);
        //            command.Parameters.AddWithValue("@datum", chat.DatumTijd);
        //            command.Parameters.AddWithValue("@bericht", chat.Bericht);

        //            command.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
    }
}