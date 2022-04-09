using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
    {
    public class ArmoiresStockEntityConfig : IEntityTypeConfiguration<ArmoiresStockEntity>
        {
        public void Configure(EntityTypeBuilder<ArmoiresStockEntity> builder)
            {
                builder.ToTable("armoires-stock");
                builder.HasComment("TRIAL");

                builder.HasKey(e => e.Mediid)
                        .HasName("PK_ArmoiresStockEntity")
                        .IsClustered();

                builder.Property(e => e.Mediid)
                        .ValueGeneratedNever()
                        .HasColumnName("mediid")
                        .IsRequired()
                        .HasComment("TRIAL");

                builder.Property(e => e.Armoireid)
                    .HasColumnName("armoireid")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Medicamentid)
                    .HasColumnType("text")
                    .HasColumnName("medicamentid")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Ordonnanceid)
                    .HasColumnName("ordonnanceid")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .IsRequired()
                    .HasComment("TRIAL");

                builder.HasOne(d => d.Armoire)
                    .WithMany(p => p.ArmoiresStocks)
                    .HasForeignKey(d => d.Armoireid)
                    .HasConstraintName("FK_ArmoiresStockEntity_ArmoiresEntity");

                builder.HasOne(d => d.Medi)
                    .WithOne(p => p.ArmoiresStock)
                    .HasForeignKey<ArmoiresStockEntity>(d => d.Mediid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicamentEntity_ArmoiresStockEntity");

                builder.HasOne(d => d.Ordonnance)
                    .WithMany(p => p.ArmoiresStocks)
                    .HasForeignKey(d => d.Ordonnanceid)
                    .HasConstraintName("FK_ArmoiresStockEntity_OrdonnanceEntity");
            }
        }
    }
