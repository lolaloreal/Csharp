using System;
using System.Collections.Generic;

namespace cbelt.Models
{
    public class Auction: BaseEntity
    {
        public int AuctionId {get;set;}
        public string ProductName {get;set;}
        public string Description {get;set;}
        public double StartingBid {get;set;}
        public DateTime EndDate {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}


        public List<Bid> Bids {get;set;}
        public Auction()
        {
            Bids = new List<Bid>();
        }
    }
}