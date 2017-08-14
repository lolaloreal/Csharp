using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models{

    public class Review
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        public string Reviewer { get; set; }

        [Required]
        public string Restaurant { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public DateTime DateVisited { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}