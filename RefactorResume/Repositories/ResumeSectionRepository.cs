using Microsoft.Data.SqlClient;
using RefactorResume.Models;
using System;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public class ResumeSectionRepository : BaseRepository, IResumeSectionRepository
    {
        private readonly string _connectionString;

        public ResumeSectionRepository(IConfiguration configuration) : base(configuration) { }

        public ResumeSection Get(int id)
        {
            ResumeSection resumeSection = null;
            string query = "SELECT ID, ResumeID, SectionType FROM resume_sections WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        resumeSection = new ResumeSection
                        {
                            ID = (int)reader["ID"],
                            ResumeID = (int)reader["ResumeID"],
                            SectionType = reader["SectionType"] as string
                        };
                    }
                }
            }

            return resumeSection;
        }

        public void Add(ResumeSection resumeSection)
        {
            string query = "INSERT INTO resume_sections (ResumeID, SectionType) VALUES (@ResumeID, @SectionType)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ResumeID", resumeSection.ResumeID);
                    command.Parameters.AddWithValue("@SectionType", resumeSection.SectionType);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(ResumeSection resumeSection)
        {
            string query = "UPDATE resume_sections SET ResumeID = @ResumeID, SectionType = @SectionType WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", resumeSection.ID);
                    command.Parameters.AddWithValue("@ResumeID", resumeSection.ResumeID);
                    command.Parameters.AddWithValue("@SectionType", resumeSection.SectionType);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM resume_sections WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
