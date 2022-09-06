using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_LearningBackendAPI.Entities
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(60, ErrorMessage = "Author can't be longer than 60 characters")]
        public string Author { get; set; }

        public List<Lesson> Lessons { get; } = new List<Lesson>();
    }
}
