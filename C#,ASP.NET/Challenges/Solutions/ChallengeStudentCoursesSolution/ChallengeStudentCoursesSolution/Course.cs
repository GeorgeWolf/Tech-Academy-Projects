using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCoursesSolution
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}