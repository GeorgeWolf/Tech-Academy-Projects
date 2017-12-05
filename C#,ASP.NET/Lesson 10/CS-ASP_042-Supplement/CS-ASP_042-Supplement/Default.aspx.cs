using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_042_Supplement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            Student student = setupStudent();
            Course course = setupCourse();

            student.Enrollments.Add(setupEnrollment(course));

            course.Students.Add(student);

            StringBuilder sb = new StringBuilder();
            sb.Append("<h3>Student Details</h3><p>Id: ");
            sb.Append(student.Id);
            sb.Append("<br/>Name: ");
            sb.Append(student.Name);
            sb.Append("<br/>Enrollments: ");
            foreach (var enrollment in student.Enrollments)
            {
                sb.Append("<br/>&nbsp;&nbsp;");
                sb.Append(enrollment.Course.Title);
                sb.Append(" -- ");
                sb.Append(enrollment.GradePoint);
            }

            sb.Append("</p><h3>Courses</h3><p>Id: ");
            sb.Append(course.Id);
            sb.Append("<br/>Title: ");
            sb.Append(course.Title);
            sb.Append("<br/>Facility: ");
            sb.Append(course.Room.Building);
            sb.Append(" -- ");
            sb.Append(course.Room.RoomNumber);
            sb.Append("<br/>Students:");
            foreach (Student studentInCourse in course.Students)
            {
                sb.Append("<br/>&nbsp;&nbsp;");
                sb.Append(studentInCourse.Id);
                sb.Append(" -- ");
                sb.Append(studentInCourse.Name);
            }
            sb.Append("</br>Times:");
            foreach (Schedule schedule in course.Schedule)
            {
                sb.Append("<br/>&nbsp;&nbsp;");
                sb.Append(schedule.DayOfWeek);
                sb.Append(" -- ");
                sb.Append(schedule.TimeBegin);
                sb.Append(" -- (");
                sb.Append(schedule.DurationInMinutes);
                sb.Append(" minutes)");
            }
            sb.Append("</p>");

            resultLabel.Text = sb.ToString();
        }

        private Student setupStudent()
        {
            Student student = new Student();
            student.Id = 1;
            student.Name = "Bob Tabor";
            student.Enrollments = new List<Enrollment>();
            return student;
        }

        private Enrollment setupEnrollment(Course course)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.Course = course;
            enrollment.GradePoint = 93;
            return enrollment;
        }

        private Course setupCourse()
        {
            Course course = new Course();
            course.Id = 1;
            course.Room = setupRoom();
            course.Title = "C# 101";
            course.Schedule = setupSchedule();
            course.Students = new List<Student>();
            return course;
        }

        private Room setupRoom()
        {
            Room room = new Room();
            room.Building = "Emerging Technologies Building";
            room.RoomNumber = 23;
            return room;
        }

        private Schedule[] setupSchedule()
        {
            Schedule[] schedule = new Schedule[3];

            Schedule schedule0 = new Schedule();
            schedule0.DayOfWeek = 2;
            schedule0.TimeBegin = 8;
            schedule0.DurationInMinutes = 90;

            Schedule schedule1 = new Schedule();
            schedule1.DayOfWeek = 4;
            schedule1.TimeBegin = 8;
            schedule1.DurationInMinutes = 90;

            Schedule schedule2 = new Schedule();
            schedule2.DayOfWeek = 6;
            schedule2.TimeBegin = 9;
            schedule2.DurationInMinutes = 60;

            schedule[0] = schedule0;
            schedule[1] = schedule1;
            schedule[2] = schedule2;

            return schedule;
        }
    }
}