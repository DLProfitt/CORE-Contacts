using Microsoft.Data.SqlClient;
using RefactorResume.Models;
using System;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public class WorkExperienceRepository : BaseRepository, IWorkExperienceRepository
    {
        public WorkExperienceRepository(IConfiguration configuration) : base(configuration) { }

        public List<WorkExperience> GetAllWorkExperiences()
        {
            var workExperiences = new List<WorkExperience>();

            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM work_experience", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workExperiences.Add(new WorkExperience
                        {
                            ID = reader.GetInt32(0),
                            SectionID = reader.GetInt32(1),
                            Company = reader.GetString(2),
                            Role = reader.GetString(3),
                            Location = reader.GetString(4),
                            Summary = reader.GetString(5)
                        });
                    }
                }
            }

            return workExperiences;
        }

        public WorkExperience GetWorkExperienceById(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM work_experience WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new WorkExperience
                            {
                                ID = reader.GetInt32(0),
                                SectionID = reader.GetInt32(1),
                                Company = reader.GetString(2),
                                Role = reader.GetString(3),
                                Location = reader.GetString(4),
                                Summary = reader.GetString(5)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void AddWorkExperience(WorkExperience workExperience)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO work_experience (SectionID, Company, Role, Location, Summary) VALUES (@SectionID, @Company, @Role, @Location, @Summary)", connection))
                {
                    command.Parameters.AddWithValue("@SectionID", workExperience.SectionID);
                    command.Parameters.AddWithValue("@Company", workExperience.Company);
                    command.Parameters.AddWithValue("@Role", workExperience.Role);
                    command.Parameters.AddWithValue("@Location", workExperience.Location);
                    command.Parameters.AddWithValue("@Summary", workExperience.Summary);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWorkExperience(WorkExperience workExperience)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "UPDATE work_experience SET SectionID = @SectionID, Company = @Company, Role = @Role, Location = @Location, Summary = @Summary WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", workExperience.ID);
                    command.Parameters.AddWithValue("@SectionID", workExperience.SectionID);
                    command.Parameters.AddWithValue("@Company", workExperience.Company);
                    command.Parameters.AddWithValue("@Role", workExperience.Role);
                    command.Parameters.AddWithValue("@Location", workExperience.Location);
                    command.Parameters.AddWithValue("@Summary", workExperience.Summary);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteWorkExperience(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "DELETE FROM work_experience WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
