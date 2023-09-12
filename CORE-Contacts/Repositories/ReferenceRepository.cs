using Microsoft.Data.SqlClient;
using COREContacts.Data;
using COREContacts.Models;
using System;
using System.Collections.Generic;

namespace COREContacts.Repositories
{
    public class ReferenceRepository : BaseRepository, IReferenceRepository // Inherit from BaseRepository
    {
        public ReferenceRepository(IConfiguration configuration) : base(configuration) { }

        public List<Reference> GetAllReferences()
        {
            List<Reference> references = new List<Reference>();

            using (SqlConnection connection = Connection) // Use Connection property from BaseRepository
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [references]", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            references.Add(new Reference
                            {
                                ID = (int)reader["ID"],
                                SectionID = (int)reader["SectionID"],
                                ReferenceType = reader["ReferenceType"].ToString(),
                                ReferenceName = reader["ReferenceName"].ToString(),
                                ReferenceBusinessRole = reader["ReferenceBusinessRole"].ToString(),
                                ReferencePhoneNumber = reader["ReferencePhoneNumber"].ToString(),
                                ReferenceEmail = reader["ReferenceEmail"].ToString()
                            });
                        }
                    }
                }
            }

            return references;
        }

        public Reference GetReferenceById(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [references] WHERE ID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reference
                            {
                                ID = (int)reader["ID"],
                                SectionID = (int)reader["SectionID"],
                                ReferenceType = reader["ReferenceType"].ToString(),
                                ReferenceName = reader["ReferenceName"].ToString(),
                                ReferenceBusinessRole = reader["ReferenceBusinessRole"].ToString(),
                                ReferencePhoneNumber = reader["ReferencePhoneNumber"].ToString(),
                                ReferenceEmail = reader["ReferenceEmail"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AddReference(Reference reference)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO [references] (SectionID, ReferenceType, ReferenceName, ReferenceBusinessRole, ReferencePhoneNumber, ReferenceEmail) VALUES (@SectionID, @ReferenceType, @ReferenceName, @ReferenceBusinessRole, @ReferencePhoneNumber, @ReferenceEmail)", connection))
                {
                    command.Parameters.AddWithValue("@SectionID", reference.SectionID);
                    command.Parameters.AddWithValue("@ReferenceType", reference.ReferenceType);
                    command.Parameters.AddWithValue("@ReferenceName", reference.ReferenceName);
                    command.Parameters.AddWithValue("@ReferenceBusinessRole", reference.ReferenceBusinessRole);
                    command.Parameters.AddWithValue("@ReferencePhoneNumber", reference.ReferencePhoneNumber);
                    command.Parameters.AddWithValue("@ReferenceEmail", reference.ReferenceEmail);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateReference(Reference reference)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "UPDATE [references] SET SectionID = @SectionID, ReferenceType = @ReferenceType, ReferenceName = @ReferenceName, ReferenceBusinessRole = @ReferenceBusinessRole, ReferencePhoneNumber = @ReferencePhoneNumber, ReferenceEmail = @ReferenceEmail WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", reference.ID);
                    command.Parameters.AddWithValue("@SectionID", reference.SectionID);
                    command.Parameters.AddWithValue("@ReferenceType", reference.ReferenceType);
                    command.Parameters.AddWithValue("@ReferenceName", reference.ReferenceName);
                    command.Parameters.AddWithValue("@ReferenceBusinessRole", reference.ReferenceBusinessRole);
                    command.Parameters.AddWithValue("@ReferencePhoneNumber", reference.ReferencePhoneNumber);
                    command.Parameters.AddWithValue("@ReferenceEmail", reference.ReferenceEmail);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteReference(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM [references] WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
