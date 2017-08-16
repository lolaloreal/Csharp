//this is the layer where the data coming back from SQL gets mapped

using Microsoft.EntityFrameworkCore;
using bankAccount.Models;

namespace bankAccount.Models
{
    public class BankContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankContext(DbContextOptions<BankContext> options) : base(options) { } 
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    
    }
}