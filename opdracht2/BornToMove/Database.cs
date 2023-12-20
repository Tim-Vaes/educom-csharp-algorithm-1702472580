using Microsoft.Data.SqlClient;

namespace BornToMove
{
    public class Database
    {
        private readonly string connectionString;

        public Database()
        {
            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=born2move;Integrated Security=True;";
        }

        public Move GetRandomMove()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 * FROM dbo.move ORDER BY NEWID();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapMoveFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<Move> GetMoveList()
        {
            List<Move> moveList = new List<Move>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.move;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            moveList.Add(MapMoveFromReader(reader));
                        }
                    }
                }
            }
            return moveList;
        }

        public bool DoesMoveExist(string moveName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM dbo.move WHERE Name = @MoveName;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MoveName", moveName);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public void AddMove(Move move)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO dbo.move (Name, Description, SweatRate) VALUES (@Name, @Description, @SweatRate);";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", move.Name);
                        command.Parameters.AddWithValue("@Description", move.Description);
                        command.Parameters.AddWithValue("@SweatRate", move.SweatRate);
                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private Move MapMoveFromReader(SqlDataReader reader)
        {
            return new Move
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                SweatRate = Convert.ToInt32(reader["SweatRate"])
            };
        }
    }
}

