using RefactorResume.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public class EducationRepository : BaseRepository, IEducationRepository
    {
        private readonly string _connectionString;

        public EducationRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<Education> GetEducations()
        {
            var educations = new List<Education>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM education", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var education = new Education
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                SectionID = reader.GetInt32(reader.GetOrdinal("SectionID")),
                                SchoolName = reader.GetString(reader.GetOrdinal("SchoolName")),
                                DegreeReceived = reader.GetString(reader.GetOrdinal("DegreeReceived")),
                                GraduationDate = reader.GetDateTime(reader.GetOrdinal("GraduationDate"))
                            };
                            educations.Add(education);
                        }
                    }
                }
            }

            return educations;
        }

        public void AddEducation(Education education)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO education (SectionID, SchoolName, DegreeReceived, GraduationDate) VALUES (@SectionID, @SchoolName, @DegreeReceived, @GraduationDate)", connection))
                {
                    command.Parameters.AddWithValue("@SectionID", education.SectionID);
                    command.Parameters.AddWithValue("@SchoolName", education.SchoolName);
                    command.Parameters.AddWithValue("@DegreeReceived", education.DegreeReceived);
                    command.Parameters.AddWithValue("@GraduationDate", education.GraduationDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEducation(Education education)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE education SET SectionID = @SectionID, SchoolName = @SchoolName, DegreeReceived = @DegreeReceived, GraduationDate = @GraduationDate WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", education.ID);
                    command.Parameters.AddWithValue("@SectionID", education.SectionID);
                    command.Parameters.AddWithValue("@SchoolName", education.SchoolName);
                    command.Parameters.AddWithValue("@DegreeReceived", education.DegreeReceived);
                    command.Parameters.AddWithValue("@GraduationDate", education.GraduationDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEducation(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM education WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
