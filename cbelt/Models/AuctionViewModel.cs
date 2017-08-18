using System;
using System.ComponentModel.DataAnnotations;
using cbelt.Models;

namespace cbelt.Models
{
    public class AuctionViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Product Name is required.")]
        [MinLength(3, ErrorMessage = "Must have at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(10, ErrorMessage = "Must have at least 10 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Starting Bid is required.")]
        public double StartingBid { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime EndDate { get; set; }

    }
}