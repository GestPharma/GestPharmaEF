using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
    {
    public class ArmoireEntityConfig : IEntityTypeConfiguration<ArmoireEntity>
        {
        public void Configure(EntityTypeBuilder<ArmoireEntity> builder)
            {
            builder.ToTable("armoires");
            builder.HasComment("TRIAL");

            builder.HasKey(m => m.Id)
               .HasName("PK_ArmoireEntity")
               .IsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("TRIAL");

            builder.Property(e => e.Nom)
                .HasColumnType("text")
                .HasColumnName("nom")
                .IsRequired()
                .HasComment("TRIAL");
            }
        }
    }
