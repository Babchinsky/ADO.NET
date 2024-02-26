using Microsoft.EntityFrameworkCore;

namespace _26._02._2024_Entity_Framework
{
    public class CountriesContext : DbContext
    {
        public DbSet<PartOfTheWorld> PartOfTheWorlds { get; set; }
        public DbSet<Country> Countries { get; set; }

        public CountriesContext()
        {
            if (Database.EnsureCreated())
            {
                // Создание всех частей света
                PartOfTheWorld europe = new PartOfTheWorld { Name = "Europe" };
                PartOfTheWorld africa = new PartOfTheWorld { Name = "Africa" };
                PartOfTheWorld asia = new PartOfTheWorld { Name = "Asia" };
                PartOfTheWorld northAmerica = new PartOfTheWorld { Name = "North America" };
                PartOfTheWorld southAmerica = new PartOfTheWorld { Name = "South America" };
                PartOfTheWorld australia = new PartOfTheWorld { Name = "Australia" };
                PartOfTheWorld antarctica = new PartOfTheWorld { Name = "Antarctica" };

                PartOfTheWorlds?.Add(europe);
                PartOfTheWorlds?.Add(africa);
                PartOfTheWorlds?.Add(asia);
                PartOfTheWorlds?.Add(northAmerica);
                PartOfTheWorlds?.Add(southAmerica);
                PartOfTheWorlds?.Add(australia);
                PartOfTheWorlds?.Add(antarctica);

                // Создание 10 стран
                Countries?.Add(new Country { Name = "Ukraine", Capital = "Kyiv", Area = 603628, NumberOfInhabitants = 337000000, PartOfTheWorld = europe });
                Countries?.Add(new Country { Name = "Egypt", Capital = "Cairo", Area = 1002450, NumberOfInhabitants = 104258327, PartOfTheWorld = africa });
                Countries?.Add(new Country { Name = "China", Capital = "Beijing", Area = 9596960, NumberOfInhabitants = 1403500365, PartOfTheWorld = asia });
                Countries?.Add(new Country { Name = "USA", Capital = "Washington, D.C.", Area = 9833517, NumberOfInhabitants = 331002651, PartOfTheWorld = northAmerica });
                Countries?.Add(new Country { Name = "Brazil", Capital = "Brasília", Area = 8515767, NumberOfInhabitants = 212559417, PartOfTheWorld = southAmerica });
                Countries?.Add(new Country { Name = "Australia", Capital = "Canberra", Area = 7692024, NumberOfInhabitants = 25499884, PartOfTheWorld = australia });
                Countries?.Add(new Country { Name = "Argentina", Capital = "Buenos Aires", Area = 2780400, NumberOfInhabitants = 45195777, PartOfTheWorld = southAmerica });
                Countries?.Add(new Country { Name = "Canada", Capital = "Ottawa", Area = 9976140, NumberOfInhabitants = 37742154, PartOfTheWorld = northAmerica });
                Countries?.Add(new Country { Name = "India", Capital = "New Delhi", Area = 3287263, NumberOfInhabitants = 1380004385, PartOfTheWorld = asia });
                Countries?.Add(new Country { Name = "England", Capital = "London", Area = 130395, NumberOfInhabitants = 67886011, PartOfTheWorld = europe });

                SaveChanges();
            }
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // метод UseLazyLoadingProxies() делает доступной ленивую загрузку.
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=LEGION;Database=Countries;Integrated Security=True;TrustServerCertificate=true");
    
        }

    }

}
