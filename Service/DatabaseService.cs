using Microsoft.Data.Sqlite;
using ProjectDataBase.Model;


namespace ProjectDataBase.Service // 💡 גם כאן לשנות לשם הפרויקט שלכם
{
    public class DatabaseService
    {
        // נתיב לקובץ בסיס הנתונים שלנו
        private string _connectionString = "Data Source=Data/database.db";

        // פונקציה שמחזירה רשימה של משתמשים
        public List<User> GetAllUsers()
        {
            List<User> usersList = new List<User>(); // רשימה ריקה

            // פתיחת חיבור למסד הנתונים
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // כתיבת פקודת השליפה
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Users";

                // ביצוע הפקודה וקריאת התוצאות שורה-אחר-שורה
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // חילוץ הנתונים מהשורה בדיוק לפי שמות העמודות בטבלה
                        int id = Convert.ToInt32(reader["id"]);
                        string fullName = reader["FullName"].ToString();
                        string userName = reader["UserName"].ToString();
                        string password = reader["Password"].ToString();

                        // יצירת אובייקט מסוג משתמש והוספתו לרשימה
                        User u = new User(id, fullName, userName, password);
                        usersList.Add(u);
                    }
                }
            }

            return usersList; // החזרת הרשימה המלאה
        }
    }
}