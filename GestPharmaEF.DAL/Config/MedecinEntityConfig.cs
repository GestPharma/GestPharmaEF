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
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("email")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Fax)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("fax")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Gsm)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("gsm")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Inami)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("inami")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Nom)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("nom")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Rue)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("rue")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Telephone)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("telephone")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Ville)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("ville")
                    .IsRequired()
                    .HasComment("TRIAL");
            }
        }
    }
