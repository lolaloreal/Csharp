//this is the layer where the data coming back from SQL gets mapped

using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;

namespace RESTauranter.Models
{
    public class RestContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }
        public DbSet<Review> Reviews { get; set; }
    }
}