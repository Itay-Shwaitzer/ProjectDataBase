// מחלקה שמייצגת תמונה/פוסט במערכת

namespace ProjectDataBase.Model
{
    public class GameImage
    {
        private int id;
        private string title = "";
        private string imageUrl = "";
        private string description = "";

        // יוצר אובייקט ריק
        public GameImage() { }

        // יוצר אובייקט עם כל הנתונים
        public GameImage(int id, string title, string imageUrl, string description)
        {
            this.id = id;
            this.title = title;
            this.imageUrl = imageUrl;
            this.description = description;
        }

        // מחזיר את ה-ID של התמונה
        public int GetId() { return id; }

        // מחזיר את כותרת התמונה
        public string GetTitle() { return title; }

        // מחזיר את הקישור לתמונה
        public string GetImageUrl() { return imageUrl; }

        // מחזיר את התיאור של התמונה
        public string GetDescription() { return description; }
    }
}