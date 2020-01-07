using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using leantraining.Models;

namespace leantraining.DataAccess
{
    public partial class LeanTrainingDbContext : DbContext
    {
        public LeanTrainingDbContext()
        {
        }

        public LeanTrainingDbContext(DbContextOptions<LeanTrainingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssemblySteps> AssemblySteps { get; set; }
        public virtual DbSet<PartDefinitions> PartDefinitions { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Rounds> Rounds { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<StationsAssemblyStepss> StationsAssemblyStepss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=data/leandb.db;foreign keys=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssemblySteps>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<PartDefinitions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Parts>(entity =>
            {
                entity.HasIndex(e => e.PartDefinitionId);

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.PartDefinition)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.PartDefinitionId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.RoundId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Start)
                    .IsRequired()
                    .HasDefaultValueSql("datetime('now')");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.RoundId);
            });

            modelBuilder.Entity<Rounds>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Start)
                    .IsRequired()
                    .HasDefaultValueSql("datetime('now')");
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.HasIndex(e => e.RoundId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Position).IsRequired();

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.Stations)
                    .HasForeignKey(d => d.RoundId);
            });

            modelBuilder.Entity<StationsAssemblyStepss>(entity =>
            {
                entity.HasIndex(e => e.AssemblyStepId);

                entity.HasIndex(e => e.StationId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AssemblyStep)
                    .WithMany(p => p.StationsAssemblyStepss)
                    .HasForeignKey(d => d.AssemblyStepId);

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationsAssemblyStepss)
                    .HasForeignKey(d => d.StationId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
