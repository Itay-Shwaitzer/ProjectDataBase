// מחלקה שמבצעת פעולות מול בסיס הנתונים

using Microsoft.Data.Sqlite;
using ProjectDataBase.Model;

namespace ProjectDataBase.Service
{
    public class DatabaseService
    {
        private string _connectionString = "Data Source=Data/WebDataBase.db";

        // מחזירה את כל המשתמשים מהטבלה
        public List<User> GetAllUsers()
        {
            List<User> usersList = new List<User>();

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Users";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string fullName = reader["FullName"].ToString();
                        string userName = reader["Username"].ToString();
                        string password = reader["Password"].ToString();
                        string role = reader["Role"].ToString();

                        User u = new User(id, fullName, userName, password, role);
                        usersList.Add(u);
                    }
                }
            }

            return usersList;
        }

        // מוסיפה משתמש חדש לטבלת Users
        public void AddUser(User user)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "INSERT INTO Users (FullName, Username, Password, Role) VALUES (@FullName, @Username, @Password, @Role)";

                command.Parameters.AddWithValue("@FullName", user.GetFullName());
                command.Parameters.AddWithValue("@Username", user.GetUserName());
                command.Parameters.AddWithValue("@Password", user.GetPassword());
                command.Parameters.AddWithValue("@Role", user.GetRole());

                command.ExecuteNonQuery();
            }
        }

        // בודקת אם שם המשתמש כבר קיים
        public bool UserExists(string userName)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                command.Parameters.AddWithValue("@Username", userName);

                long count = (long)command.ExecuteScalar();

                return count > 0;
            }
        }

        // מוחקת משתמש לפי ה-ID
        public void DeleteUser(int id)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Users WHERE Id = @Id";

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        // מעדכנת שם ותפקיד של משתמש
        public void UpdateUser(int id, string fullName, string role)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "UPDATE Users SET FullName = @FullName, Role = @Role WHERE Id = @Id";

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Role", role);

                command.ExecuteNonQuery();
            }
        }
    }
}