using Abby.Models;

using Microsoft.EntityFrameworkCore;

namespace Abby.DataAccess.Data
{
    public class ApplicationDBContext:DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        { 
        
        
        }
       

        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }

    }
}
