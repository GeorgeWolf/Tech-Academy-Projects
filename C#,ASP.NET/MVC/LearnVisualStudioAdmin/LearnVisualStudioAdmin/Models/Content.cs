using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LearnVisualStudioAdmin.Models
{
    public class Content
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-z][a-z0-9-]+$", ErrorMessage = "Segment must begin with a lowercase letter, and only include lowercase letters, numbers and dashes.")]
        public string Segment { get; set; }

        // Descriptive name used for display to admins
        [Required]
        public string AdminFriendlyName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        [UIHint("DateTimePicker")]
        public DateTime Published { get; set; }

        [Required]
        public int OrdinalPosition { get; set; }

        //public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<Tag> Tags { get; set; }
        //public virtual ICollection<Download> Downloads { get; set; }
    }
}