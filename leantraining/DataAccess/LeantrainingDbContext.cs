using leantraining.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace leantraining.DataAccess
{
    public class LeantrainingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            if (!ob.IsConfigured)
            {
                ob.UseSqlite("DataSource=data/leandb.db;foreign keys=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            var product = Setup<Product>(mb);
            product.Property(x => x.Start)
                   .HasDefaultValueSql("datetime('now')");
            product.Property(x => x.End);
            product.HasOne(x => x.Round)
                   .WithMany(x => x.Products)
                   .IsRequired();
            
            var station = Setup<Station>(mb);
            station.Property(x => x.Position)
                   .HasMaxLength(50)
                   .IsRequired();
            station.HasOne(x => x.Round)
                   .WithMany(x => x.Stations)
                   .IsRequired();
            
            var partDef = Setup<PartDefinition>(mb);
            partDef.Property(x => x.Cost)
                   .IsRequired();
            partDef.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            var assemblyStep = Setup<AssemblyStep>(mb);
            assemblyStep.Property(x => x.Cost)
                   .IsRequired();
            assemblyStep.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            var round = Setup<Round>(mb);
            round.Property(x => x.Start)
                 .HasDefaultValueSql("datetime('now')");
            round.Property(x => x.End);
            var part = Setup<Part>(mb);
            part.HasOne(x => x.Product)
                .WithMany(x => x.Parts);
            part.HasOne(x => x.PartDefinition)
                .WithMany(x => x.Parts);

            var assStatStep = Setup<StationAssemblyStep>(mb);
            assStatStep.HasOne(x => x.Station)
                       .WithMany(x => x.AssemblySteps);
            assStatStep.HasOne(x => x.AssemblyStep)
                       .WithMany(x => x.StationAssemblySteps);

            base.OnModelCreating(mb);
        }

        private static EntityTypeBuilder<T> Setup<T>(ModelBuilder mb)
            where T : Entity
        {
            var entity = mb.Entity<T>();
            entity.HasKey(x => x.Id);
            entity.ToTable(typeof(T).Name + "s");

            return entity;
        }
    }
}
