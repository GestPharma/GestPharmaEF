using GestPharmaEF.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestPharmaEF.DAL.Config
{
    public class PersonneEntityConfig : IEntityTypeConfiguration<PersonneEntity>
    {
        public void Configure(EntityTypeBuilder<PersonneEntity> builder)
        {
            builder.ToTable("personne");
            builder.HasComment("TRIAL");

            builder.HasKey(m => m.Id)
           .HasName("PK_PersonneEntity")
           .IsClustered();

            builder.Property(e => e.Email)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("email")
            .IsRequired()
            .HasComment("TRIAL");

            builder.Property(e => e.IsActive)
            .HasColumnType("Bit")
            .HasColumnName("IsActive")
            .IsRequired()
            .HasComment("TRIAL");

            builder.Property(e => e.ConnectAs)
            .HasColumnType("nvarchar(256)")
            .HasColumnName("connectAs")
            .IsRequired()
            .HasComment("TRIAL");

            builder.Property(e => e.CurrentRoleId)
                .HasColumnName("currentroleid")
                .HasComment("TRIAL");

            //builder.HasOne(d => d.Roles)
            //.WithMany(p => p.Personnes)
            //.HasForeignKey(d => d.CurrentRoleId)
            //.HasConstraintName("FK_Personne_Role_RoleId");

            builder.HasMany(u => u.Roles)
                    .WithMany(r => r.Personnes)
                    .UsingEntity<RoleEntity>(
                        userRole => userRole.HasOne<RoleEntity>()
                            .WithMany()
                            .HasForeignKey(ur => ur.Id)
                            .IsRequired(),
                        userRole => userRole.HasOne<PersonneEntity>()
                            .WithMany()
                            .HasForeignKey(us => us.Id)
                            .IsRequired());

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
