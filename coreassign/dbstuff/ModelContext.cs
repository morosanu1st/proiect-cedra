using coreassign.Models;
using Microsoft.EntityFrameworkCore;

namespace coreassign.dbstuff
{
    public class ModelContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Route> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=tracking;user=admin;password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasKey(e => e.IdPackage);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne<User>(e => e.Receiver).WithMany(p => p.Received).HasForeignKey(p => p.ReceiverId);
                entity.HasOne<User>(e => e.Sender).WithMany(p => p.Sent).HasForeignKey(p => p.SenderId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.IdRoute);
                entity.HasOne(e => e.Package).WithMany(p => p.Route).HasForeignKey(p => p.PackageId);
            });
        }
    }
}