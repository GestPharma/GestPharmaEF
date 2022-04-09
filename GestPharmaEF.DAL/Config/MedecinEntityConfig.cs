using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
    {
    public class MedecinEntityConfig : IEntityTypeConfiguration<MedecinEntity>
        {
        public void Configure(EntityTypeBuilder<MedecinEntity> builder)
            {
                builder.ToTable("medecins");
                builder.HasComment("TRIAL");

                builder.HasKey(e => e.IdMedecin)
                    .HasName("PK_MedecinEntity")
                    .IsClustered();

                builder.Property(e => e.IdMedecin)
                    .HasColumnName("id_medecin")
                    .HasComment("TRIAL");

                builder.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Fax)
                    .HasColumnType("text")
                    .HasColumnName("fax")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Gsm)
                    .HasColumnType("text")
                    .HasColumnName("gsm")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Inami)
                    .HasColumnType("text")
                    .HasColumnName("inami")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Rue)
                    .HasColumnType("text")
                    .HasColumnName("rue")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Telephone)
                    .HasColumnType("text")
                    .HasColumnName("telephone")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Ville)
                    .HasColumnType("text")
                    .HasColumnName("ville")
                    .IsRequired()
                    .HasComment("TRIAL");
            }
        }
    }
