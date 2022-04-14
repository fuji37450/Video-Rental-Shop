namespace store
{
    public class Video
    {
        public string Name { get; private set; }
        public string Category { get; private set; }

        public Video(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}
