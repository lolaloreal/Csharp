using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cbelt.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public List<Bid> UserBids {get;set;}

        public User()
        {
            UserBids = new List<Bid>();
        }
    }
    
}