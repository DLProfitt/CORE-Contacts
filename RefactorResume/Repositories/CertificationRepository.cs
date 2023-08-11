using RefactorResume.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace RefactorResume.Data
{
    public class CertificationRepository : BaseRepository, ICertificationRepository
    {
        private readonly string _connectionString;

        public CertificationRepository(IConfiguration configuration) : base(configuration) { }

        public List<Certification> GetAllCertifications()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM certifications", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Certification> certifications = new List<Certification>();
                        while (reader.Read())
                        {
                            certifications.Add(new Certification
                            {
                                ID = reader.GetInt32(0),
                                SectionID = reader.GetInt32(1),
                                CertificationTitle = reader.GetString(2),
                                DateReceived = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                            });
                        }
                        return certifications;
                    }
                }
            }
        }

        public Certification GetCertificationById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM certifications WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Certification
                            {
                                ID = reader.GetInt32(0),
                                SectionID = reader.GetInt32(1),
                                CertificationTitle = reader.GetString(2),
                                DateReceived = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void AddCertification(Certification certification)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO certifications (SectionID, CertificationTitle, DateReceived) VALUES (@SectionID, @CertificationTitle, @DateReceived)", connection))
                {
                    command.Parameters.AddWithValue("@SectionID", certification.SectionID);
                    command.Parameters.AddWithValue("@CertificationTitle", certification.CertificationTitle);
                    command.Parameters.AddWithValue("@DateReceived", certification.DateReceived);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCertification(Certification certification)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE certifications SET SectionID = @SectionID, CertificationTitle = @CertificationTitle, DateReceived = @DateReceived WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", certification.ID);
                    command.Parameters.AddWithValue("@SectionID", certification.SectionID);
                    command.Parameters.AddWithValue("@CertificationTitle", certification.CertificationTitle);
                    command.Parameters.AddWithValue("@DateReceived", certification.DateReceived);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCertification(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM certifications WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
