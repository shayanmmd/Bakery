using Bakery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Persistence.DbContexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        #region DbSets
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Suggestion> Suggestions { get; set; }
        DbSet<Domain.Entities.Bakery> Bakeries { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne<User>(c=>c.Customer).WithMany(g=>g.Orders);            
        }
    }
}
