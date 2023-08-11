using Microsoft.Data.SqlClient;
using RefactorResume.Models;
using System;
using System.Collections.Generic;

namespace RefactorResume.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Skill> GetAllSkills()
        {
            List<Skill> skills = new List<Skill>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM skills";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Skill skill = new Skill
                    {
                        ID = (int)reader["ID"],
                        SectionID = (int)reader["SectionID"],
                        SkillType = reader["SkillType"] as string,
                        SkillName = reader["SkillName"] as string
                    };

                    skills.Add(skill);
                }

                reader.Close();
            }

            return skills;
        }

        public Skill GetSkillById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM skills WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Skill skill = new Skill
                    {
                        ID = (int)reader["ID"],
                        SectionID = (int)reader["SectionID"],
                        SkillType = reader["SkillType"] as string,
                        SkillName = reader["SkillName"] as string
                    };

                    reader.Close();
                    return skill;
                }

                reader.Close();
                return null;
            }
        }

        public void AddSkill(Skill skill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO skills (SectionID, SkillType, SkillName) VALUES (@sectionId, @skillType, @skillName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sectionId", skill.SectionID);
                command.Parameters.AddWithValue("@skillType", skill.SkillType);
                command.Parameters.AddWithValue("@skillName", skill.SkillName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateSkill(Skill skill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE skills SET SectionID = @sectionId, SkillType = @skillType, SkillName = @skillName WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", skill.ID);
                command.Parameters.AddWithValue("@sectionId", skill.SectionID);
                command.Parameters.AddWithValue("@skillType", skill.SkillType);
                command.Parameters.AddWithValue("@skillName", skill.SkillName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSkill(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM skills WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
