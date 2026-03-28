// מחלקה שמייצגת תמונה במערכת

namespace ProjectDataBase.Model
{
    public class GameImage
    {
        private int id;
        private string title = "";
        private string imageUrl = "";
        private string description = "";

        public GameImage() { }

        public GameImage(int id, string title, string imageUrl, string description)
        {
            this.id = id;
            this.title = title;
            this.imageUrl = imageUrl;
            this.description = description;
        }

        public int GetId() { return id; }

        public string GetTitle() { return title; }

        public string GetImageUrl() { return imageUrl; }

        public string GetDescription() { return description; }
    }
}