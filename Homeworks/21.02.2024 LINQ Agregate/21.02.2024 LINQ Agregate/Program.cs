public class Good
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}



public class Program
{
    public static void PrintGoods(List<Good> goods)
    {
        foreach (Good good in goods)
        {
            Console.WriteLine($"{good.Id,-5} {good.Title,-20} {good.Price,-15} {good.Category}");
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        // Устанавливаем кодировку консоли на UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Good> goods = new List<Good>()
        {
            new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good() { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good() { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good() { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good() { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good() { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good() { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good() { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good() { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good() { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
        };
        PrintGoods(goods);

        var mobileProductsOver1000 = goods
            .Where(g => g.Category == "Mobile" && g.Price > 1000)
            .ToList();
        Console.WriteLine("1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.");
        PrintGoods(mobileProductsOver1000);


        var nonKitchenProductsOver1000 = goods
            .Where(g => g.Category != "Kitchen" && g.Price > 1000)
            .ToList();
        Console.WriteLine("2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen,\r\nцена которых превышает 1000 грн.");
        PrintGoods(nonKitchenProductsOver1000);

        var averagePrice = goods.Average(g => g.Price);
        Console.WriteLine("3) Вычислить среднее значение всех цен товаров");
        Console.WriteLine(averagePrice + "\n");

        var distinctCategories = goods
            .Select(g => g.Category).Distinct();
        Console.WriteLine("4) Вывести список категорий без повторений.");
        foreach(var category in distinctCategories) Console.WriteLine(category);
        Console.WriteLine();

        var orderedGoods = goods.OrderBy(good => good.Title);
        Console.WriteLine("5) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по\r\nназванию.");
        foreach (var good in orderedGoods) Console.WriteLine($"{good.Title, -20} {good.Category}");
        Console.WriteLine();

        var numberOfProductsInCarAndMobileCategories = goods
            .Where(g => g.Category == "Car" || g.Category == "Mobile")
            .Sum(g => 1);

        Console.WriteLine("6) Посчитать суммарное количество товаров категорий Сar и Mobile.");
        Console.WriteLine(numberOfProductsInCarAndMobileCategories + "\n");


        var categoryCounts = goods
            .GroupBy(g => g.Category)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count()
            });

        Console.WriteLine("7) Вывести список категорий и количество товаров каждой категории.");
        foreach (var categoryCount in categoryCounts)
        {
            Console.WriteLine($"{categoryCount.Category, -10} {categoryCount.Count}");
        }
    }
}