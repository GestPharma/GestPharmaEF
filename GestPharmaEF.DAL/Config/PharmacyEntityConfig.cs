using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
    {
    public class PharmacyEntityConfig : IEntityTypeConfiguration<PharmacyEntity>
        {
        public void Configure(EntityTypeBuilder<PharmacyEntity> builder)
            {
                builder.ToTable("pharmacies");
                builder.HasComment("TRIAL");

                builder.HasKey(m => m.Id)
                   .HasName("PK_PharmacyEntity")
                   .IsClustered();

                builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                builder.Property(e => e.Departement)
                    .HasColumnType("text")
                    .HasColumnName("departement")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Region)
                    .HasColumnType("text")
                    .HasColumnName("region")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Rue)
                    .HasColumnType("text")
                    .HasColumnName("rue")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Titulaires)
                    .HasColumnType("text")
                    .HasColumnName("titulaires")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Villes)
                    .HasColumnType("text")
                    .HasColumnName("villes")
                    .IsRequired()
                    .HasComment("TRIAL");
            }
        }
    }
