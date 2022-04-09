using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
    {
    public class OrdonnanceEntityConfig : IEntityTypeConfiguration<OrdonnanceEntity>
        {
        public void Configure(EntityTypeBuilder<OrdonnanceEntity> builder)
            {
                builder.ToTable("ordonnances");
                builder.HasComment("TRIAL");

                builder.HasKey(m => m.Id)
                   .HasName("PK_OrdonnanceEntity")
                   .IsClustered();

                builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                builder.Property(e => e.Datecree)
                    .HasColumnType("date")
                    .HasColumnName("datecree")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Dateexpire)
                    .HasColumnType("date")
                    .HasColumnName("dateexpire")
                    .HasComment("TRIAL");

                builder.Property(e => e.Medecinid)
                    .HasColumnName("medecinid")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Pharmacieid)
                    .HasColumnName("pharmacieid")
                    .HasComment("TRIAL");

                builder.HasOne(d => d.Medecin)
                    .WithMany(p => p.Ordonnances)
                    .HasForeignKey(d => d.Medecinid)
                    .HasConstraintName("FK_OrdonnanceEntity_MedecinEntity");

                builder.HasOne(d => d.Pharmacie)
                    .WithMany(p => p.Ordonnances)
                    .HasForeignKey(d => d.Pharmacieid)
                    .HasConstraintName("FK_OrdonnanceEntity_PharmacyEntity");
            }
        }
    }
