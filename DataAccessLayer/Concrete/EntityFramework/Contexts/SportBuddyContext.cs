using CoreLayer.Entities.Concerete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts
{
    public class SportBuddyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-8T9IQ2C;Initial Catalog=SportBuddyDB;Integrated Security=True;TrustServerCertificate=true");
        }

       // public DbSet<Product> Products { get; set; }
      //  public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<JoinTheActivity> JoinTheActivities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             modelBuilder
                .Entity<User>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });
            */
        }
    }
}
