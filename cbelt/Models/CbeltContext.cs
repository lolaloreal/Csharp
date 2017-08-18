//this is the layer where the data coming back from SQL gets mapped

using Microsoft.EntityFrameworkCore;
using cbelt.Models;

namespace cbelt.Models
{
    public class CbeltContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public CbeltContext(DbContextOptions<CbeltContext> options) : base(options) { } 
        public DbSet<User> Users { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Bid> Bids { get; set; }
    
    }
}