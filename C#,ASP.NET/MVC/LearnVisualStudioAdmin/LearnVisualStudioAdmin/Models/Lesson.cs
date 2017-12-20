using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace LearnVisualStudioAdmin.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }

        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}