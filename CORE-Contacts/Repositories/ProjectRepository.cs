using Microsoft.Data.SqlClient;
using COREContacts.Data;
using COREContacts.Models;
using System;
using System.Collections.Generic;

namespace COREContacts.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<Project> GetAllProjects()
        {
            var projects = new List<Project>();

            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM projects", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var project = new Project
                            {
                                ID = (int)reader["ID"],
                                SectionID = (int)reader["SectionID"],
                                ProjectTitle = reader["ProjectTitle"]?.ToString(),
                                ProjectDetails = reader["ProjectDetails"]?.ToString(),
                                ProjectSummary = reader["ProjectSummary"]?.ToString(),
                                LinkToProject = reader["LinkToProject"]?.ToString()
                            };
                            projects.Add(project);
                        }
                    }
                }
            }

            return projects;
        }

        public void AddProject(Project project)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO projects (SectionID, ProjectTitle, ProjectDetails, ProjectSummary, LinkToProject) VALUES (@SectionID, @ProjectTitle, @ProjectDetails, @ProjectSummary, @LinkToProject)", connection))
                {
                    command.Parameters.AddWithValue("@SectionID", project.SectionID);
                    command.Parameters.AddWithValue("@ProjectTitle", project.ProjectTitle ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectDetails", project.ProjectDetails ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectSummary", project.ProjectSummary ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LinkToProject", project.LinkToProject ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProject(Project project)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "UPDATE projects SET SectionID = @SectionID, ProjectTitle = @ProjectTitle, ProjectDetails = @ProjectDetails, ProjectSummary = @ProjectSummary, LinkToProject = @LinkToProject WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", project.ID);
                    command.Parameters.AddWithValue("@SectionID", project.SectionID);
                    command.Parameters.AddWithValue("@ProjectTitle", project.ProjectTitle ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectDetails", project.ProjectDetails ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectSummary", project.ProjectSummary ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LinkToProject", project.LinkToProject ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProject(int id)
        {
            using (SqlConnection connection = Connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM projects WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
