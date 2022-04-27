using BookMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookMvc.Data
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }

        

      



        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            
           

            
        }
    
        
    }
}