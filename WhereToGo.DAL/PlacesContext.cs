using Microsoft.EntityFrameworkCore;

namespace WhereToGo.DAL.Domain
{
    public class PlacesContext : DbContext
    {
        public PlacesContext(DbContextOptions<PlacesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceTag> PlaceTags { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PlaceTag>()
                .HasKey(pt => new {pt.PlaceId, pt.TagId});

            builder.Entity<PlaceTag>()
                .HasOne(pt => pt.Place)
                .WithMany(p => p.PlaceTags)
                .HasForeignKey(pt => pt.PlaceId);

            builder.Entity<PlaceTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PlaceTags)
                .HasForeignKey(pt => pt.TagId);

            builder.Entity<Place>()
                .HasMany(c => c.Photos)
                .WithOne(e => e.Place);
        }
    }
}