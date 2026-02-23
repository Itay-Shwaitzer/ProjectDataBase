namespace ProjectDataBase.Model
{
    public class User
    {
        private int id;
        private string fullName;
        private string userName;
        private string password;

        public User(int id, string fullName, string userName, string password)
        {
            this.id = id;
            this.fullName = fullName;
            this.userName = userName;
            this.password = password;
        }
        public int GetId() { return this.id; }
        public string GetFullName() { return this.fullName; }
        public string GetUserName() { return this.userName; }
        public string GetPassword() { return this.password; }
    }
}
