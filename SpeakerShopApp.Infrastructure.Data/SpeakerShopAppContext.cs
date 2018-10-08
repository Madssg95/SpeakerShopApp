using Microsoft.EntityFrameworkCore;
using SpeakerShopApp.Core.Entity;

namespace SpeakerShopApp.Infrastructure.Data
{
    public class SpeakerShopAppContext : DbContext
    {
        public SpeakerShopAppContext(DbContextOptions<SpeakerShopAppContext> opt) : base(opt)
        {
        }

        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Speaker>().HasOne(s => s.Brand).WithMany(b => b.Speaker).OnDelete(DeleteBehavior.SetNull);
        }
    }
}