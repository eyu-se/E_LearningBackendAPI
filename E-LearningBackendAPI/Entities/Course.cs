using System;

namespace E_LearningBackendAPI.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
