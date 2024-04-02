using FriendsTown.Domain;
using Microsoft.EntityFrameworkCore;

namespace FriendsTown.Data
{
    public class FriendsTownContext : DbContext
    {
        public FriendsTownContext(DbContextOptions<FriendsTownContext> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Activity>().Property(a => a.Name).HasMaxLength(30);
            modelBuilder.Entity<Activity>().Property(a => a.Description).IsRequired();

            modelBuilder.Entity<Friend>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Friend>().Property(a => a.Name).HasMaxLength(30);
            modelBuilder.Entity<Friend>().Property(a => a.Email).IsRequired();
            modelBuilder.Entity<Friend>().Property(a => a.Email).HasMaxLength(60);
            modelBuilder.Entity<Friend>().Property(a => a.Phone).HasMaxLength(30);

            modelBuilder.Entity<News>().Property(n => n.Description).IsRequired();

            modelBuilder.Entity<News>().OwnsOne(n => n.Date);
            modelBuilder.Entity<News>().OwnsOne(n => n.Place);

            modelBuilder.Entity<Event>().OwnsOne(o => o.Place);
            modelBuilder.Entity<Event>().OwnsOne(o => o.Date);
        }
    }
}
