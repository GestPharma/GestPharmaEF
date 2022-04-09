using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
    {
    public class MedicamentsPrescritEntityConfig : IEntityTypeConfiguration<MedicamentsPrescritEntity>
        {
        public void Configure(EntityTypeBuilder<MedicamentsPrescritEntity> builder)
            {
                builder.HasNoKey();
                builder.ToTable("medicaments-prescrits");
                builder.HasComment("TRIAL");

                builder.Property(e => e.Medicamentid)
                    .HasColumnName("medicamentid")
                    .HasComment("TRIAL");

                builder.Property(e => e.Ordonnanceid)
                    .HasColumnName("ordonnanceid")
                    .HasComment("TRIAL");

                builder.Property(e => e.Prise)
                    .HasColumnName("prise")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.HasOne(d => d.Medicament)
                    .WithMany()
                    .HasForeignKey(d => d.Medicamentid)
                    .HasConstraintName("FK_MedicamentsPrescritEntity_MedicamentEntity");

                builder.HasOne(d => d.Ordonnance)
                    .WithMany()
                    .HasForeignKey(d => d.Ordonnanceid)
                    .HasConstraintName("FK_MedicamentsPrescritEntity_OrdonnanceEntity");
            }
        }
    }
