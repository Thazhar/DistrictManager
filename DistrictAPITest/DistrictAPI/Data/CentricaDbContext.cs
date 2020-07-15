using DistrictAPITest.Models;
using Microsoft.EntityFrameworkCore;

namespace DistrictAPITest.Data
{
    public partial class CentricaDbContext : DbContext
    {

        public CentricaDbContext(DbContextOptions<CentricaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<SecondarySeller> SecondarySeller { get; set; }


        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-3FCRGRC;Initial Catalog=Centrica;User ID=DistrictAPI;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>(entity =>
            {
                entity.HasIndex(e => e.DistrictName)
                    .HasName("UQ__district__9E05AFF9C70BC431")
                    .IsUnique();

                entity.Property(e => e.DistrictName).IsUnicode(false);

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__district__seller__245D67DE");
            });

            modelBuilder.Entity<SecondarySeller>(entity =>
            {
                entity.HasKey(e => new { e.SellerId, e.DistrictId })
                    .HasName("PK__secondar__DA5819B5EE903D0C");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.SecondarySeller)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__secondary__distr__2B0A656D");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.SecondarySeller)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__secondary__selle__2A164134");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.Property(e => e.SellerName).IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreName).IsUnicode(false);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__store__district___2739D489");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        

    }
}
