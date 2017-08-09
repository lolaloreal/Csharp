using System;
using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models
{
    public class Quote
    {
        public int id { get; set; }

        public string name { get; set; }

        public string quote { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt {get; set; }

    }
}