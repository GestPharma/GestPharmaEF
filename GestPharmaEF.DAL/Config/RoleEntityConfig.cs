using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config 
{
    public class RoleEntityConfig : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("role");
            builder.HasComment("TRIAL");

            builder.HasKey(m => m.Id)
           .HasName("PK_RoleEntity")
           .IsClustered();

            builder.Property(e => e.Name)
            .HasColumnType("String")
            .HasColumnName("Name")
            .IsRequired()
            .HasComment("TRIAL");
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
