using Microsoft.Data.SqlClient;
using RefactorResume.Data;
using RefactorResume.Models;

namespace RefactorResume.Repositories
{
    public class ObjectiveRepository : BaseRepository, IObjectiveRepository
    {
        public ObjectiveRepository(IConfiguration configuration) : base(configuration) { }

        public Objective GetObjective(int id)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT ID, SectionID, ObjectiveText FROM objective WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Objective
                            {
                                ID = reader.GetInt32(0),
                                SectionID = reader.GetInt32(1),
                                ObjectiveText = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void AddObjective(Objective objective)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO objective (SectionID, ObjectiveText) VALUES (@SectionID, @ObjectiveText)", connection))
                {
                    command.Parameters.AddWithValue("@SectionID", objective.SectionID);
                    command.Parameters.AddWithValue("@ObjectiveText", objective.ObjectiveText);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateObjective(Objective objective)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE objective SET SectionID = @SectionID, ObjectiveText = @ObjectiveText WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", objective.ID);
                    command.Parameters.AddWithValue("@SectionID", objective.SectionID);
                    command.Parameters.AddWithValue("@ObjectiveText", objective.ObjectiveText);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteObjective(int id)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM objective WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
