// מחלקה שמייצגת משתמש במערכת עם כל הפרטים שלו

namespace ProjectDataBase.Model
{
    public class User
    {
        private int id;
        private string fullName;
        private string userName;
        private string password;
        private string role;

        // מאפשר ליצור משתמש ריק ולמלא נתונים בהמשך
        public User() { }

        // יוצר משתמש עם כל הנתונים מראש
        public User(int id, string fullName, string userName, string password, string role)
        {
            this.id = id;
            this.fullName = fullName;
            this.userName = userName;
            this.password = password;
            this.role = role;
        }

        // מחזיר את ה-ID של המשתמש
        public int GetId() { return id; }

        // מעדכן את ה-ID של המשתמש
        public void SetId(int value) { id = value; }

        // מחזיר את השם המלא של המשתמש
        public string GetFullName() { return fullName; }

        // מעדכן את השם המלא של המשתמש
        public void SetFullName(string value) { fullName = value; }

        // מחזיר את שם המשתמש
        public string GetUserName() { return userName; }

        // מעדכן את שם המשתמש
        public void SetUserName(string value) { userName = value; }

        // מחזיר את הסיסמה
        public string GetPassword() { return password; }

        // מעדכן את הסיסמה
        public void SetPassword(string value) { password = value; }

        // מחזיר את התפקיד (admin / user)
        public string GetRole() { return role; }

        // מעדכן את התפקיד של המשתמש
        public void SetRole(string value) { role = value; }
    }
}