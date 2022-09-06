using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningBackendAPI.Entities
{
    public class Lesson
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string LessonContent { get; set; }

        [Required(ErrorMessage = "Course Id is required")]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }


    }
}
