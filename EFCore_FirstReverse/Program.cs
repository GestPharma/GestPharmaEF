// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EFCore_DBLibrary;

namespace EFCore_FirstReverse
    {
    class Program
        {
        private static IConfigurationRoot _configuration = new ConfigurationBuilder().Build();
        private static DbContextOptionsBuilder<BDPMContext> _optionsBuilder = new();

        static void Main(string[] args)
            {
            BuildConfiguration();
            Console.WriteLine($"CNSTR: {_configuration.GetConnectionString("GestPharmaWorks")}");
            BuildOptions();
            ListMedicaments();
            ListMedecins();
            }
        static void BuildConfiguration()
            {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
            }

        static void BuildOptions()
            {
            _optionsBuilder = new DbContextOptionsBuilder<BDPMContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("GestPharmaWorks"));
            }
        static void ListMedicaments()
            {
            using (BDPMContext? db = new(_optionsBuilder.Options))
                {
                var medicaments = db.Medicaments.ToList();
                foreach (var medoc in medicaments)
                    {
                    Console.WriteLine($"{medoc.Nom}");
                    }
                }
            }
        static void ListMedecins()
            {
            using (BDPMContext? db = new(_optionsBuilder.Options))
                {
                var toubibs = db.Medecins.ToList();
                foreach (var toubib in toubibs)
                    {
                    Console.WriteLine($"{toubib.Nom} {toubib.Ville}");
                    }
                }
            }
        }
    }
