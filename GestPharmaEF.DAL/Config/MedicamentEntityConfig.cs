using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
    {
    public class MedicamentEntityConfig : IEntityTypeConfiguration<MedicamentEntity>
        {
        public void Configure(EntityTypeBuilder<MedicamentEntity> builder)
            {
                builder.ToTable("medicaments");
                builder.HasComment("TRIAL");

                builder.HasKey(m => m.Id)
                   .HasName("PK_MedicamentEntity")
                   .IsClustered();

                builder.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                builder.Property(e => e.Nom)
                    .HasColumnType("nvarchar(256)")
                    .HasColumnName("nom")
                    .IsRequired()
                    .HasComment("TRIAL");
            }
        }
    }
