using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnVisualStudioAdmin.Models
{
    public class Course : Content 
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}