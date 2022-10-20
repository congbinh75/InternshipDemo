using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace service.Models
{
    public partial class demoContext : DbContext
    {
        public demoContext()
        {
        }

        public demoContext(DbContextOptions<demoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<ContractsCovers> ContractsCovers { get; set; }
        public virtual DbSet<MasterDatas> MasterDatas { get; set; }
        public virtual DbSet<MasterTables> MasterTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=demo;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.CarBrandNavigation)
                    .WithMany(p => p.ContractsCarBrandNavigation)
                    .HasForeignKey(d => d.CarBrand)
                    .HasConstraintName("CarBrand");

                entity.HasOne(d => d.CarModelNavigation)
                    .WithMany(p => p.ContractsCarModelNavigation)
                    .HasForeignKey(d => d.CarModel)
                    .HasConstraintName("CarModel");
            });

            modelBuilder.Entity<ContractsCovers>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractsCovers)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("ContractId");

                entity.HasOne(d => d.CoverNameNavigation)
                    .WithMany(p => p.ContractsCovers)
                    .HasForeignKey(d => d.CoverName)
                    .HasConstraintName("ContractName");
            });

            modelBuilder.Entity<MasterDatas>(entity =>
            {
                entity.HasIndex(e => e.MasterTableCode);

                entity.HasIndex(e => new { e.Code, e.MasterTableCode })
                    .IsUnique();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastModifiedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.MasterTableCode).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.MasterTableCodeNavigation)
                    .WithMany(p => p.MasterDatas)
                    .HasPrincipalKey(p => p.Code)
                    .HasForeignKey(d => d.MasterTableCode);
            });

            modelBuilder.Entity<MasterTables>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("AK_MasterTables_Code")
                    .IsUnique();

                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.IsMenu).HasColumnName("isMenu");

                entity.Property(e => e.IsPrice).HasColumnName("isPrice");

                entity.Property(e => e.LastModifiedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UrlPrice).HasColumnName("urlPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
