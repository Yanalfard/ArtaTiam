﻿using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataLayer.Models
{
    public partial class ArtaTiamContext : DbContext
    {
        public ArtaTiamContext()
        {
        }

        public ArtaTiamContext(DbContextOptions<ArtaTiamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBanner> TblBanners { get; set; }
        public virtual DbSet<Models.TblBlog> TblBlogs { get; set; }
        public virtual DbSet<TblCatagory> TblCatagories { get; set; }
        public virtual DbSet<TblConfig> TblConfigs { get; set; }
        public virtual DbSet<TblContactU> TblContactUs { get; set; }
        public virtual DbSet<TblImage> TblImages { get; set; }
        public virtual DbSet<TblNegotiation> TblNegotiations { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
=> optionsBuilder
.UseLazyLoadingProxies()
.UseSqlServer("Data Source=185.55.227.74;Initial Catalog=artatiya_db;User ID=artatiya_user;Password=k9I2st!5");
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//         if (!optionsBuilder.IsConfigured)
//            {
//      #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=185.55.227.74;Initial Catalog=artatiya_db;User ID=artatiya_user;Password=k9I2st!5");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("artatiya_user")
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Models.TblBlog>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.TblBlogs)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblBlog_TblCatagory");
            });

            modelBuilder.Entity<TblCatagory>(entity =>
            {
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_TblCatagory_TblCatagory");
            });

            modelBuilder.Entity<TblImage>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
