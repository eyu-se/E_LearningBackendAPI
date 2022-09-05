using System;
using System.Collections.Generic;
using E_LearningBackendAPI.Entities;

namespace E_LearningBackendAPI.Contexts
{
    public static class DBSimulator
    {
        public static List<Course> CoursesDb = new List<Course>() {

            new Course()
                {
                    Id = 1,
                    Name = "Diplomacy 101",
                    Description = "Diplomacy is the main instrument of foreign policy",
                    Category = "Diplomacy",
                    Author = "Mathew",
                    Duration = new TimeSpan(30, 0, 0, 0)

                },
            new Course()
                {
                    Id = 2,
                    Name = "International Relations 101",
                    Description = " international studies is " +
                    "the scientific study of interactions between sovereign states",
                    Category = "International Relations",
                    Author = "Jhon",
                    Duration = new TimeSpan(60, 0, 0, 0)

                }

        };
    }
}
