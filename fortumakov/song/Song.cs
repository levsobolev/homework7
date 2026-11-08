namespace fortumakov.song
{
    public class Song
    {
        private string Name;
        private string Author;
        private Song Prev;

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAuthor(string author)
        {
            Author = author;
        }

        public void SetPrev(Song prev)
        {
            Prev = prev;
        }

        public string Title()
        {
            return Name + " - " + Author;
        }

        public override bool Equals(object d)
        {
            if (d == null || d is Song)
            {
                return false;
            }
            Song song = (Song)d;
            return (song.Name == Name) && (song.Author == Author);

        }
    }
}
