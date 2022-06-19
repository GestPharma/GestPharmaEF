// EntityFrameworkCore\Add-Migration MyFirstMigration
// EntityFrameworkCore\update-database

using GestPharmaEF.DAL.Config;
using GestPharmaEF.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestPharmaEF.DAL
{
    public partial class BDPMContext : IdentityDbContext<PersonneEntity, RoleEntity, long>
    {
        //public BDPMContext()
        //{
        //    Armoires = Set<ArmoireEntity>();
        //    ArmoiresStocks = Set<ArmoiresStockEntity>();
        //    Medecins = Set<MedecinEntity>();
        //    Medicaments = Set<MedicamentEntity>();
        //    MedicamentsPrescrits = Set<MedicamentsPrescritEntity>();
        //    Ordonnances = Set<OrdonnanceEntity>();
        //    Pharmacies = Set<PharmacyEntity>();
        //    Personnes = Set<PersonneEntity>();
        //    Roles = Set<RoleEntity>();
        //}

        public BDPMContext(DbContextOptions<BDPMContext> options)
            : base(options)
        {
            Armoires = Set<ArmoireEntity>();
            ArmoiresStocks = Set<ArmoiresStockEntity>();
            Medecins = Set<MedecinEntity>();
            Medicaments = Set<MedicamentEntity>();
            MedicamentsPrescrits = Set<MedicamentsPrescritEntity>();
            Ordonnances = Set<OrdonnanceEntity>();
            Pharmacies = Set<PharmacyEntity>();
            Personnes = Set<PersonneEntity>();
            Roles = Set<RoleEntity>();
        }

        public virtual DbSet<ArmoireEntity> Armoires { get; set; }
        public virtual DbSet<ArmoiresStockEntity> ArmoiresStocks { get; set; }
        public virtual DbSet<MedecinEntity> Medecins { get; set; }
        public virtual DbSet<MedicamentEntity> Medicaments { get; set; }
        public virtual DbSet<MedicamentsPrescritEntity> MedicamentsPrescrits { get; set; }
        public virtual DbSet<OrdonnanceEntity> Ordonnances { get; set; }
        public virtual DbSet<PharmacyEntity> Pharmacies { get; set; }
        public override DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<PersonneEntity> Personnes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            if (!optionsBuilder.IsConfigured)
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArmoireEntityConfig());
            modelBuilder.ApplyConfiguration(new ArmoiresStockEntityConfig());
            modelBuilder.ApplyConfiguration(new MedecinEntityConfig());
            modelBuilder.ApplyConfiguration(new MedicamentEntityConfig());
            modelBuilder.ApplyConfiguration(new MedicamentsPrescritEntityConfig());
            modelBuilder.ApplyConfiguration(new OrdonnanceEntityConfig());
            modelBuilder.ApplyConfiguration(new PharmacyEntityConfig());
            modelBuilder.ApplyConfiguration(new PersonneEntityConfig());
            modelBuilder.ApplyConfiguration(new RoleEntityConfig());


            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
