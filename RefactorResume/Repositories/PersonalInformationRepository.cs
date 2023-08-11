using Microsoft.Data.SqlClient;
using RefactorResume.Models;
using System;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public class PersonalInformationRepository : BaseRepository, IPersonalInformationRepository
    {
        private readonly string _connectionString;

        public PersonalInformationRepository(IConfiguration configuration) : base(configuration) { }

        public PersonalInformation Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM personal_information WHERE ID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PersonalInformation
                            {
                                ID = (int)reader["ID"],
                                SectionID = (int)reader["SectionID"],
                                FirstName = reader["FirstName"] as string,
                                LastName = reader["LastName"] as string,
                                Email = reader["Email"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                LinkedInProfile = reader["LinkedInProfile"] as string,
                                GitHubProfile = reader["GitHubProfile"] as string
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void Add(PersonalInformation personalInformation)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO personal_information (SectionID, FirstName, LastName, Email, PhoneNumber, LinkedInProfile, GitHubProfile) " +
                    "VALUES (@SectionID, @FirstName, @LastName, @Email, @PhoneNumber, @LinkedInProfile, @GitHubProfile)", connection))
                {
                    command.Parameters.AddWithValue("@SectionID", personalInformation.SectionID);
                    command.Parameters.AddWithValue("@FirstName", personalInformation.FirstName);
                    command.Parameters.AddWithValue("@LastName", personalInformation.LastName);
                    command.Parameters.AddWithValue("@Email", personalInformation.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", personalInformation.PhoneNumber);
                    command.Parameters.AddWithValue("@LinkedInProfile", personalInformation.LinkedInProfile);
                    command.Parameters.AddWithValue("@GitHubProfile", personalInformation.GitHubProfile);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(PersonalInformation personalInformation)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "UPDATE personal_information SET SectionID = @SectionID, FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                    "PhoneNumber = @PhoneNumber, LinkedInProfile = @LinkedInProfile, GitHubProfile = @GitHubProfile WHERE ID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", personalInformation.ID);
                    command.Parameters.AddWithValue("@SectionID", personalInformation.SectionID);
                    command.Parameters.AddWithValue("@FirstName", personalInformation.FirstName);
                    command.Parameters.AddWithValue("@LastName", personalInformation.LastName);
                    command.Parameters.AddWithValue("@Email", personalInformation.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", personalInformation.PhoneNumber);
                    command.Parameters.AddWithValue("@LinkedInProfile", personalInformation.LinkedInProfile);
                    command.Parameters.AddWithValue("@GitHubProfile", personalInformation.GitHubProfile);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM personal_information WHERE ID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
