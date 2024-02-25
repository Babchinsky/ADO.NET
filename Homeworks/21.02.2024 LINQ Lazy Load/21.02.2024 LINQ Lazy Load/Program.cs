public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}

public class Program
{
    public static void PrintPeople(List<Person> people)
    {
        foreach (var p in people)
        {
            Console.WriteLine($"{p.Name}, {p.Age} лет, {p.City}");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        // Устанавливаем кодировку консоли на UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var person = new List<Person>()
        {
            new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
            new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
            new Person(){ Name = "Oleg", Age = 15, City = "London" },
            new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
        };
        PrintPeople(person);


        Console.WriteLine("1) Выбрать людей, старших 25 лет");
        var olderThan25 = person
            .Where(p => p.Age > 25)
            .ToList();
        PrintPeople(olderThan25);



        Console.WriteLine("2) Выбрать людей, проживающих не в Лондоне");
        var notLondon = person
            .Where(p => p.City != "London")
            .ToList();
        PrintPeople(notLondon);


        Console.WriteLine("3) Выбрать имена людей, проживающих в Киеве");
        var kyiv = person
            .Where(p => p.City == "Kyiv")
            .ToList();
        PrintPeople(kyiv);


        Console.WriteLine("4) Выбрать людей, старших 35 лет, с именем Sergey");
        var sergeysOlderThan35 = person
            .Where(p => p.Name == "Sergey" && p.Age > 35)
            .ToList();
        PrintPeople(sergeysOlderThan35);


        Console.WriteLine("5) Выбрать людей, проживающих в Одессе");
        var odesa = person
            .Where(p => p.City == "Odesa")
            .ToList();
        PrintPeople(odesa);
    }
}

