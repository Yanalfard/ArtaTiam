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

        public virtual DbSet<TblConfig> TblConfigs { get; set; }
        public virtual DbSet<TblContactU> TblContactUs { get; set; }
        public virtual DbSet<TblNegotiation> TblNegotiations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=103.216.62.27;Initial Catalog=ArtaTiam;User ID=Yanal;Password=1710ahmad.fard");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}