// מחלקה ששומרת את פרטי המשתמש שמחובר כרגע

namespace ProjectDataBase.Service
{
    public class UserSessionService
    {
        private bool isLoggedIn = false;
        private string userName = "";
        private string role = "";

        // מחזיר האם יש משתמש מחובר
        public bool GetIsLoggedIn() { return isLoggedIn; }

        // מעדכן את מצב ההתחברות
        public void SetIsLoggedIn(bool value) { isLoggedIn = value; }

        // מחזיר את שם המשתמש המחובר
        public string GetUserName() { return userName; }

        // מעדכן את שם המשתמש המחובר
        public void SetUserName(string value) { userName = value; }

        // מחזיר את התפקיד של המשתמש המחובר
        public string GetRole() { return role; }

        // מעדכן את התפקיד של המשתמש המחובר
        public void SetRole(string value) { role = value; }

        // מנתקת את המשתמש
        public void Logout()
        {
            isLoggedIn = false;
            userName = "";
            role = "";
        }
    }
}