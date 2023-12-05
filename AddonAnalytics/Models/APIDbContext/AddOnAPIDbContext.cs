
using AddonAnalytics.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AddonAnalyticsAPI.Core.Models
{
    /*The Db Context class acts as a middleware between the actual EF models and the actual physical DB.
    This class decides what should go into the actual DB after the migration happens.
    It is responsible for establishing a DB connection to the SQL Server DB.*/
    public class AddOnAPIDBContext : DbContext
    {
        public AddOnAPIDBContext(DbContextOptions option) : base(option)
        {
                
        }

        public AddOnAPIDBContext()
        {
                
        }

        //In order to create a DB table based on the model class defines(say 'AddOn'), we need an entity mapping to the model class. So, we create a DbSet property

        public DbSet<AddOn> AddOn { get; set; }

        
        public DbSet<User>? User { get; set; }

        //public DbSet<AddOnMaster>? AddOnMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AddOn>().HasData(new AddOn() { }); //To add some seed data when DB is created. This is optional.
  
        }
    }
}
