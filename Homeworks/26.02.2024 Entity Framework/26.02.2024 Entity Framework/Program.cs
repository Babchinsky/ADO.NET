using System.Text;

namespace _26._02._2024_Entity_Framework
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Установка кодировки консоли на UTF-8
                Console.OutputEncoding = Encoding.UTF8;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1. Отобразить всю информацию о странах");
                    Console.WriteLine("2. Отобразить название стран");
                    Console.WriteLine("3. Отобразить название столиц");
                    Console.WriteLine("4. Отобразить название всех европейских стран");
                    Console.WriteLine("5. Отобразить название стран с площадью, которая больше\r\nконкретного числа");
                    Console.WriteLine("6. Отобразить все страны, у которых в названии есть буквы a, е; ");
                    Console.WriteLine("7. Отобразить все страны, у которых название начинается с буквы a");
                    Console.WriteLine("8. Отобразить название стран, у которых площадь находится в\r\nуказанном диапазоне");
                    Console.WriteLine("9. Отобразить название стран, у которых количество жителей больше\r\nуказанного числа");
                    Console.WriteLine("0. Выход");
                    int result = int.Parse(Console.ReadLine()!);
                    switch (result)
                    {
                        case 1:
                            DisplayAllCountriesInformation();
                            break;
                        case 2:
                            DisplayCountryNames();
                            break;
                        case 3:
                            DisplayCapitalNames();
                            break;
                        case 4:
                            DisplayEuropeanCountryNames();
                            break;
                        case 5:
                            DisplayCountriesWithAreaGreaterThan();
                            break;
                        case 6:
                            DisplayCountriesWithLettersInName();
                            break;
                        case 7:
                            DisplayCountriesStartingWithA();
                            break;
                        case 8:
                            DisplayCountriesInAreaRange();
                            break;
                        case 9:
                            DisplayCountriesWithPopulationGreaterThan();
                            break;
                        case 0:
                            return;
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayAllCountriesInformation()
        {
            Console.Clear();
            using (var db = new CountriesContext())
            {
                var countries = (from country in db.Countries
                                select country).ToList(); 

                int iter = 0;
                foreach (var country in countries)
                {
                    Console.WriteLine($"{++iter,-5} {country.Name,-20} {country.Capital,-20} {country.NumberOfInhabitants,-15} {country.Area,-15} {country.PartOfTheWorld?.Name,-20}");
                }
                


                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void DisplayCountryNames()
        {
            Console.Clear();
            using (var db = new CountriesContext())
            {
                var countriesNames = (from country in db.Countries
                                 select country.Name).ToList();

                int iter = 0;
                foreach (var countryName in countriesNames)
                {
                    Console.WriteLine($"{++iter,-5} {countryName,-20}");
                }



                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void DisplayCapitalNames()
        {
            Console.Clear();
            using (var db = new CountriesContext())
            {
                var capitals = (from country in db.Countries
                                      select country.Capital).ToList();

                int iter = 0;
                foreach (var capital in capitals)
                {
                    Console.WriteLine($"{++iter,-5} {capital,-20}");
                }



                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void DisplayEuropeanCountryNames()
        {
            Console.Clear();
            using (var db = new CountriesContext())
            {
                var europeanCountries = (from country in db.Countries
                                where country.PartOfTheWorld.Name == "Europe"
                                select country.Name).ToList();

                int iter = 0;
                foreach (var europeanCountry in europeanCountries)
                {
                    Console.WriteLine($"{++iter,-5} {europeanCountry,-20}");
                }



                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void DisplayCountriesWithAreaGreaterThan()
        {
            Console.Clear();
            Console.WriteLine("Enter number:");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int userNumber))
            {
                using (var db = new CountriesContext())
                {
                    var countries = (from country in db.Countries
                                             where country.Area > userNumber
                                             select country.Name).ToList();

                    int iter = 0;
                    foreach (var country in countries)
                    {
                        Console.WriteLine($"{++iter,-5} {country,-20}");
                    }



                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Incorrect value");
            }


           
        }
        static void DisplayCountriesWithLettersInName()
        {
            Console.Clear();
            using (var db = new CountriesContext())
            {
                var countries = (from country in db.Countries
                                 where country.Name.Contains("a") && country.Name.Contains("e")
                                 select country.Name).ToList();

                int iter = 0;
                foreach (var country in countries)
                {
                    Console.WriteLine($"{++iter,-5} {country,-20}");
                }



                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void DisplayCountriesStartingWithA()
        {
            Console.Clear();
            using (var db = new CountriesContext())
            {
                var countriesStartWithA = (from country in db.Countries
                                           where country.Name.ToLower().StartsWith("a")
                                           select country.Name).ToList();

                int iter = 0;
                foreach (var country in countriesStartWithA)
                {
                    Console.WriteLine($"{++iter,-5} {country,-20}");
                }



                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void DisplayCountriesInAreaRange()
        {
            Console.Clear();
            Console.WriteLine("Введите минимальную площадь:");
            string minAreaInput = Console.ReadLine();

            Console.WriteLine("Введите максимальную площадь:");
            string maxAreaInput = Console.ReadLine();

            if (double.TryParse(minAreaInput, out double minArea) && double.TryParse(maxAreaInput, out double maxArea))
            {
                using (var db = new CountriesContext())
                {
                    var countriesInAreaRange = (from country in db.Countries
                                                where country.Area >= minArea && country.Area <= maxArea
                                                select country.Name).ToList();

                    int iter = 0;
                    foreach (var country in countriesInAreaRange)
                    {
                        Console.WriteLine($"{++iter,-5} {country,-20}");
                    }



                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Incorrect value");
            }
        }
        static void DisplayCountriesWithPopulationGreaterThan()
        {
            Console.Clear();
            Console.WriteLine("Enter number:");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int userNumber))
            {
                using (var db = new CountriesContext())
                {
                    var countries = (from country in db.Countries
                                     where country.NumberOfInhabitants > userNumber
                                     select country.Name).ToList();

                    int iter = 0;
                    foreach (var country in countries)
                    {
                        Console.WriteLine($"{++iter,-5} {country,-20}");
                    }



                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Incorrect value");
            }
        }

    }
}