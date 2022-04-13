using System;
namespace store
{
    public class Video
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Video(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}
