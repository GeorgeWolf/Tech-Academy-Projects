using System.ComponentModel.DataAnnotations;

namespace LearnVisualStudioAdmin.Models
{
    public class VideoActivity : Activity
    {
        [Required]
        public string VimeoId { get; set; }

        [Required]
        public int? DurationMinutes { get; set; }

        [Required]
        public int? DurationSeconds { get; set; }


    }
}