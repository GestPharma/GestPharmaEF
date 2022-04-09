using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_DBLibrary
{
    public partial class BDPMContext : DbContext
    {
        public BDPMContext()
        {
        }

        public BDPMContext(DbContextOptions<BDPMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Armoire> Armoires { get; set; }
        public virtual DbSet<ArmoiresStock> ArmoiresStocks { get; set; }
        public virtual DbSet<Medecin> Medecins { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<MedicamentsPrescrit> MedicamentsPrescrits { get; set; }
        public virtual DbSet<Ordonnance> Ordonnances { get; set; }
        public virtual DbSet<Pharmacy> Pharmacies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string csbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build().GetConnectionString("GestPharmaWorks").ToString();

                optionsBuilder.UseSqlServer(csbuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armoire>(entity =>
            {
                entity.ToTable("armoires");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .HasComment("TRIAL");

                entity.Property(e => e.Patient)
                    .HasColumnType("text")
                    .HasColumnName("Patient")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<ArmoiresStock>(entity =>
            {
                entity.HasKey(e => e.Mediid)
                    .HasName("armoires-stock_pkey");

                entity.ToTable("armoires-stock");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Mediid)
                    .ValueGeneratedNever()
                    .HasColumnName("mediid")
                    .HasComment("TRIAL");

                entity.Property(e => e.Armoireid)
                    .HasColumnName("armoireid")
                    .HasComment("TRIAL");

                entity.Property(e => e.Medicamentid)
                    .HasColumnType("text")
                    .HasColumnName("medicamentid")
                    .HasComment("TRIAL");

                entity.Property(e => e.Ordonnanceid)
                    .HasColumnName("ordonnanceid")
                    .HasComment("TRIAL");

                entity.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Armoire)
                    .WithMany(p => p.ArmoiresStocks)
                    .HasForeignKey(d => d.Armoireid)
                    .HasConstraintName("armoires-stock_armoireid_fkey");

                entity.HasOne(d => d.Medi)
                    .WithOne(p => p.ArmoiresStock)
                    .HasForeignKey<ArmoiresStock>(d => d.Mediid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("armoires-stock_mediid_fkey");

                entity.HasOne(d => d.Ordonnance)
                    .WithMany(p => p.ArmoiresStocks)
                    .HasForeignKey(d => d.Ordonnanceid)
                    .HasConstraintName("armoires-stock_ordonnanceid_fkey");
            });

            modelBuilder.Entity<Medecin>(entity =>
            {
                entity.HasKey(e => e.IdMedecin)
                    .HasName("medecins_pkey");

                entity.ToTable("medecins");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdMedecin)
                    .HasColumnName("id_medecin")
                    .HasComment("TRIAL");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email")
                    .HasComment("TRIAL");

                entity.Property(e => e.Fax)
                    .HasColumnType("text")
                    .HasColumnName("fax")
                    .HasComment("TRIAL");

                entity.Property(e => e.Gsm)
                    .HasColumnType("text")
                    .HasColumnName("gsm")
                    .HasComment("TRIAL");

                entity.Property(e => e.Inami)
                    .HasColumnType("text")
                    .HasColumnName("inami")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .HasComment("TRIAL");

                entity.Property(e => e.Rue)
                    .HasColumnType("text")
                    .HasColumnName("rue")
                    .HasComment("TRIAL");

                entity.Property(e => e.Telephone)
                    .HasColumnType("text")
                    .HasColumnName("telephone")
                    .HasComment("TRIAL");

                entity.Property(e => e.Ville)
                    .HasColumnType("text")
                    .HasColumnName("ville")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.ToTable("medicaments");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<MedicamentsPrescrit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("medicaments-prescrits");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Medicamentid)
                    .HasColumnName("medicamentid")
                    .HasComment("TRIAL");

                entity.Property(e => e.Ordonnanceid)
                    .HasColumnName("ordonnanceid")
                    .HasComment("TRIAL");

                entity.Property(e => e.Prise)
                    .HasColumnName("prise")
                    .HasComment("TRIAL");

                entity.Property(e => e.Quantite)
                    .HasColumnName("quantite")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Medicament)
                    .WithMany()
                    .HasForeignKey(d => d.Medicamentid)
                    .HasConstraintName("medicaments-prescrits_medicamentid_fkey");

                entity.HasOne(d => d.Ordonnance)
                    .WithMany()
                    .HasForeignKey(d => d.Ordonnanceid)
                    .HasConstraintName("medicaments-prescrits_ordonnanceid_fkey");
            });

            modelBuilder.Entity<Ordonnance>(entity =>
            {
                entity.ToTable("ordonnances");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Datecree)
                    .HasColumnType("date")
                    .HasColumnName("datecree")
                    .HasComment("TRIAL");

                entity.Property(e => e.Dateexpire)
                    .HasColumnType("date")
                    .HasColumnName("dateexpire")
                    .HasComment("TRIAL");

                entity.Property(e => e.Medecinid)
                    .HasColumnName("medecinid")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .HasComment("TRIAL");

                entity.Property(e => e.Pharmacieid)
                    .HasColumnName("pharmacieid")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Medecin)
                    .WithMany(p => p.Ordonnances)
                    .HasForeignKey(d => d.Medecinid)
                    .HasConstraintName("ordonnances_medecinid_fkey");

                entity.HasOne(d => d.Pharmacie)
                    .WithMany(p => p.Ordonnances)
                    .HasForeignKey(d => d.Pharmacieid)
                    .HasConstraintName("ordonnances_pharmacieid_fkey");
            });

            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.ToTable("pharmacies");

                entity.HasComment("TRIAL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.Departement)
                    .HasColumnType("text")
                    .HasColumnName("departement")
                    .HasComment("TRIAL");

                entity.Property(e => e.Nom)
                    .HasColumnType("text")
                    .HasColumnName("nom")
                    .HasComment("TRIAL");

                entity.Property(e => e.Region)
                    .HasColumnType("text")
                    .HasColumnName("region")
                    .HasComment("TRIAL");

                entity.Property(e => e.Rue)
                    .HasColumnType("text")
                    .HasColumnName("rue")
                    .HasComment("TRIAL");

                entity.Property(e => e.Titulaires)
                    .HasColumnType("text")
                    .HasColumnName("titulaires")
                    .HasComment("TRIAL");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url")
                    .HasComment("TRIAL");

                entity.Property(e => e.Villes)
                    .HasColumnType("text")
                    .HasColumnName("villes")
                    .HasComment("TRIAL");
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasComment("TRIAL");

                entity.Property(e => e.RoleId)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.RoleName)
                    .HasColumnType("string")
                    .HasColumnName("name")
                    .HasComment("TRIAL");
            });
            modelBuilder.Entity<Personne>(entity =>
            {
                entity.ToTable("personnes");

                entity.HasComment("TRIAL");

                entity.Property(e => e.PId)
                    .HasColumnName("id")
                    .HasComment("TRIAL");

                entity.Property(e => e.PEmail)
                    .HasColumnType("string")
                    .HasColumnName("email")
                    .HasComment("TRIAL");

                entity.Property(e => e.PPassword)
                    .HasColumnType("string")
                    .HasColumnName("password")
                    .HasComment("TRIAL");

                entity.Property(e => e.PIsActive)
                    .HasColumnType("bool")
                    .HasColumnName("isActive")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.CurrentRole)
                    .HasForeignKey(d => d.PRoleid)
                    .HasConstraintName("FK_Personne_Role_RoleId");

                entity.Property(e => e.PConnectAs)
                    .HasColumnType("string")
                    .HasColumnName("connectAs")
                    .HasComment("TRIAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}