using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnVisualStudioAdmin.Models
{
    public abstract class Activity : Content
    {
        [Required]
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ActivityRole> ActivityRoles { get; set; } = new List<ActivityRole>();

    }
}