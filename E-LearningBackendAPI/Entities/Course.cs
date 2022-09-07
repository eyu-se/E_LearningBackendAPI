using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningBackendAPI.Entities
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Category Id is required")]
        [ForeignKey(nameof(CourseCategory))]
        public int CourseCategoryId { get; set; }
        public CourseCategory CourseCategory { get; set; }


        [Required(ErrorMessage = "Author is required")]
        [StringLength(60, ErrorMessage = "Author can't be longer than 60 characters")]
        public string Author { get; set; }

        public List<Lesson> Lessons { get; } = new List<Lesson>();

    }
}
