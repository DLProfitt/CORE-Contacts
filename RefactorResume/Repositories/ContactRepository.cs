using Microsoft.Data.SqlClient;
using RefactorResume.Models;
using System;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(IConfiguration configuration) : base(configuration) { }

        public List<Contact> GetContacts()
        {
            var contacts = new List<Contact>();

            using (SqlConnection connection = Connection)
            {
                connection.Open();
                string query = "SELECT * FROM contacts";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                            {
                                ID = reader.GetInt32(0),
                                UserID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                                TwitterUsername = reader.IsDBNull(5) ? null : reader.GetString(5),
                                ImageUrl = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Note = reader.IsDBNull(7) ? null : reader.GetString(7),
                                IsFavorite = reader.GetBoolean(8)
                            });
                        }
                    }
                }
            }

            return contacts;
        }

        public Contact GetContact(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                string query = "SELECT * FROM contacts WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Contact
                            {
                                ID = reader.GetInt32(0),
                                UserID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                                TwitterUsername = reader.IsDBNull(5) ? null : reader.GetString(5),
                                ImageUrl = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Note = reader.IsDBNull(7) ? null : reader.GetString(7),
                                IsFavorite = reader.GetBoolean(8)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void AddContact(Contact contact)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                string query = "INSERT INTO contacts (UserID, FirstName, LastName, Email, TwitterUsername, ImageUrl, Note, IsFavorite) VALUES (@UserID, @FirstName, @LastName, @Email, @TwitterUsername, @ImageUrl, @Note, @IsFavorite)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", (object)contact.UserID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Email", (object)contact.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TwitterUsername", (object)contact.TwitterUsername ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageUrl", (object)contact.ImageUrl ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Note", (object)contact.Note ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsFavorite", contact.IsFavorite);
                    contact.ID = command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                string query = "UPDATE contacts SET UserID = @UserID, FirstName = @FirstName, LastName = @LastName, Email = @Email, TwitterUsername = @TwitterUsername, ImageUrl = @ImageUrl, Note = @Note, IsFavorite = @IsFavorite WHERE ID = @ID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", contact.ID);
                    command.Parameters.AddWithValue("@UserID", (object)contact.UserID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Email", (object)contact.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TwitterUsername", (object)contact.TwitterUsername ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageUrl", (object)contact.ImageUrl ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Note", (object)contact.Note ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsFavorite", contact.IsFavorite);
                    command.ExecuteNonQuery();

                    int affectedRows = command.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {affectedRows}");
                }
            }
        }

        public void DeleteContact(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                string query = "DELETE FROM contacts WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
