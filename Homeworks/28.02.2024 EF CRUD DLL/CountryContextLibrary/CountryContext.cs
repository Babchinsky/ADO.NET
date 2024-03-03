using Microsoft.EntityFrameworkCore;
using CountryLibrary;
using Microsoft.Extensions.Configuration;

// Для работы с БД MS SQL Server необходимо добавить пакет:
// Microsoft.EntityFrameworkCore.SqlServer(представляет функциональность Entity Framework для работы с MS SQL Server)

// Lazy loading или ленивая загрузка предполагает неявную автоматическую загрузку связанных данных при обращении к навигационному свойству.
// Microsoft.EntityFrameworkCore.Proxies

namespace CountryContextLibrary
{
    namespace _26._02._2024_Entity_Framework
    {
        public class CountryContext : DbContext
        {
            static DbContextOptions<CountryContext> _options;
            public DbSet<PartOfTheWorld> PartOfTheWorlds { get; set; }
            public DbSet<Country> Countries { get; set; }

            static CountryContext()
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("DefaultConnection");

                var optionsBuilder = new DbContextOptionsBuilder<CountryContext>();
                _options = optionsBuilder.UseSqlServer(connectionString).Options;
            }

            public CountryContext()
            : base(_options)
            {
                if (Database.EnsureCreated()) 
                {
                    // Добавление частей света
                    PartOfTheWorld europe = new PartOfTheWorld { Name = "Europe" };
                    PartOfTheWorld asia = new PartOfTheWorld { Name = "Asia" };
                    PartOfTheWorld africa = new PartOfTheWorld { Name = "Africa" };
                    PartOfTheWorld northAmerica = new PartOfTheWorld { Name = "North America" };
                    PartOfTheWorld southAmerica = new PartOfTheWorld { Name = "South America" };
                    PartOfTheWorld australia = new PartOfTheWorld { Name = "Australia" };

                    PartOfTheWorlds?.Add(europe);
                    PartOfTheWorlds?.Add(asia);
                    PartOfTheWorlds?.Add(africa);
                    PartOfTheWorlds?.Add(northAmerica);
                    PartOfTheWorlds?.Add(southAmerica);
                    PartOfTheWorlds?.Add(australia);

                    // Добавление стран
                    Countries?.Add(new Country { Name = "Ukraine", Capital = "Kyiv", Area = 603628, Population = 43790000, PartOfTheWorld = europe });
                    Countries?.Add(new Country { Name = "China", Capital = "Beijing", Area = 9596960, Population = 1403500365, PartOfTheWorld = asia });
                    Countries?.Add(new Country { Name = "Nigeria", Capital = "Abuja", Area = 923768, Population = 211400708, PartOfTheWorld = africa });
                    Countries?.Add(new Country { Name = "USA", Capital = "Washington, D.C.", Area = 9833517, Population = 332915073, PartOfTheWorld = northAmerica });
                    Countries?.Add(new Country { Name = "Brazil", Capital = "Brasília", Area = 8515767, Population = 213993437, PartOfTheWorld = southAmerica });
                    Countries?.Add(new Country { Name = "Australia", Capital = "Canberra", Area = 7692024, Population = 25788208, PartOfTheWorld = australia });
                    Countries?.Add(new Country { Name = "Germany", Capital = "Berlin", Area = 357022, Population = 83783942, PartOfTheWorld = europe });
                    Countries?.Add(new Country { Name = "India", Capital = "New Delhi", Area = 3287263, Population = 1393409038, PartOfTheWorld = asia });
                    Countries?.Add(new Country { Name = "South Africa", Capital = "Pretoria", Area = 1221037, Population = 60041968, PartOfTheWorld = africa });
                    Countries?.Add(new Country { Name = "Mexico", Capital = "Mexico City", Area = 1964375, Population = 126190788, PartOfTheWorld = northAmerica });


                    SaveChanges();
                }
            }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // метод UseLazyLoadingProxies() делает доступной ленивую загрузку.
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
}
