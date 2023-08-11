using Microsoft.Data.SqlClient;
using RefactorResume.Models;
using System;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public class ResumeRepository : BaseRepository, IResumeRepository
    {
        public ResumeRepository(IConfiguration configuration) : base(configuration) { }

        public Resume GetResume(int id)
        {
            using SqlConnection connection = Connection;
            connection.Open();

            using SqlCommand command = new SqlCommand("SELECT ID, UserID FROM resumes WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Resume resume = new Resume
                {
                    ID = reader.GetInt32(0),
                    UserID = reader.GetInt32(1)
                };

                return resume;
            }

            return null;
        }

        public List<Resume> GetAllResumes()
        {
            List<Resume> resumes = new List<Resume>();

            using SqlConnection connection = Connection;
            connection.Open();

            using SqlCommand command = new SqlCommand("SELECT ID, UserID FROM resumes", connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Resume resume = new Resume
                {
                    ID = reader.GetInt32(0),
                    UserID = reader.GetInt32(1)
                };

                resumes.Add(resume);
            }

            return resumes;
        }

        public void AddResume(Resume resume)
        {
            using SqlConnection connection = Connection;
            connection.Open();

            using SqlCommand command = new SqlCommand("INSERT INTO resumes (UserID) VALUES (@UserID); SELECT SCOPE_IDENTITY();", connection);
            command.Parameters.AddWithValue("@UserID", resume.UserID);

            resume.ID = Convert.ToInt32(command.ExecuteScalar());
        }

        public void UpdateResume(Resume resume)
        {
            using SqlConnection connection = Connection;
            connection.Open();

            using SqlCommand command = new SqlCommand("UPDATE resumes SET UserID = @UserID WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@UserID", resume.UserID);
            command.Parameters.AddWithValue("@ID", resume.ID);

            command.ExecuteNonQuery();
        }

        public void DeleteResume(int id)
        {
            using SqlConnection connection = Connection;
            connection.Open();

            using SqlCommand command = new SqlCommand("DELETE FROM resumes WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
        }
    }
}
