using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models{

    public class Review
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        [Display(Name="Reviewer")]
        public string Reviewer { get; set; }

        [Required]
        [Display(Name="Restaurant")]
        public string Restaurant { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name="Content")]
        public string Content { get; set; }

        [Required]
        [Display(Name="Rating")]
        public int Rating { get; set; }

        [Required]
        public DateTime DateVisited { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}