using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCoursesSolution
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
            */

            List<Course> courses = new List<Course>() {
                new Course() { CourseId = 1, Name = "Econ 101", Students = new List<Student>() {
                    new Student() { StudentId = 1, Name = "Bob Tabor"},
                    new Student() { StudentId = 2, Name = "Steve Jaworski"}}},
                new Course() { CourseId = 2, Name = "Discrete Math", Students = new List<Student>() {
                    new Student() { StudentId = 3, Name = "Brian Faley" },
                    new Student() { StudentId = 4, Name = "Chuck Ravetto"}}},
                new Course() { CourseId = 3, Name = "History 302", Students = new List<Student>() {
                    new Student() { StudentId = 5, Name = "Andrew Flowers"},
                    new Student() { StudentId = 6, Name = "Andrew Sekala"}}}
            };

            foreach (var course in courses)
            {
                resultLabel.Text += String.Format("<br/>Course: {0} - {1}", course.CourseId, course.Name);
                foreach (var student in course.Students)
                {
                    resultLabel.Text += String.Format("<br/>&nbsp;&nbsp;Student: {0} - {1}", student.StudentId, student.Name);
                }
            }
        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
            */

            Course course1 = new Course() { CourseId = 1, Name = "Algebra 3" };
            Course course2 = new Course() { CourseId = 2, Name = "Psychology" };
            Course course3 = new Course() { CourseId = 3, Name = "Business Law" };

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 1, new Student { StudentId = 1, Name = "Bob Tabor", Courses = new List<Course> { course1, course2 }}},
                { 2, new Student { StudentId = 2, Name = "Steve Jaworski", Courses = new List<Course> { course2, course3 }}},
                { 3, new Student { StudentId = 3, Name = "Chuck Ravetto", Courses = new List<Course> { course3, course1 }}}
            };

            foreach (var student in students)
            {
                resultLabel.Text += String.Format("<br/>Student: {0} - {1}", student.Value.StudentId, student.Value.Name);
                foreach (var course in student.Value.Courses)
                {
                    resultLabel.Text += String.Format("<br/>&nbsp;&nbsp;Course: {0} {1}", course.CourseId, course.Name);
                }
            }
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
            */

            Student student = new Student();
            student.StudentId = 10;
            student.Name = "Pete Wentz";
            student.Enrollments = new List<Enrollment>() {
                new Enrollment { Grade = 92, Course = new Course { CourseId = 1, Name = "Physiology 101" }},
                new Enrollment { Grade = 96, Course = new Course { CourseId = 2, Name = "Project Management 432"}}
            };

            resultLabel.Text = String.Format("<br/>Student: {0} {1}", student.StudentId, student.Name);
            foreach (var enrollment in student.Enrollments)
            {
                resultLabel.Text += String.Format("<br/>Enrolled In: {0} - Grade: {1}", enrollment.Course.Name, enrollment.Grade);
            }

        }
    }
}