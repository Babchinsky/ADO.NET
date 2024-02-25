class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}
class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}
class Program
{
    static void Main()
    {
        // Устанавливаем кодировку консоли на UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Department> departments = new List<Department>()
        { 
            new Department(){ Id = 1, Country = "Ukraine", City = "Odesa"},
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = " Ukraine ", City = "Lviv"}
        };

        List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
            },
            new Employee()
            {
                Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
            },
            new Employee()
            {
                Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
            },
            new Employee()
            {
                Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
            },
            new Employee()
            {
                Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
            },
            new Employee()
            {
                Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
            },
            new Employee()
            {
                Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
            }
        };

        var ukraineEmployees = employees
            .Where(emp => departments.Any(dep => dep.Id == emp.DepId && dep.Country.Trim().Equals("Ukraine", StringComparison.OrdinalIgnoreCase)))
            .OrderBy(emp => emp.FirstName)
            .ThenBy(emp => emp.LastName)
            .ToList();

        Console.WriteLine("Отсортировать имена и фамилии сотрудников по алфавиту, проживающих в Украине:");
        foreach (var employee in ukraineEmployees)
        {
            Console.WriteLine($"Имя: {employee.FirstName}, Фамилия: {employee.LastName}");
        }
        Console.WriteLine();



        var sortedEmployeesByAge = employees
            .OrderByDescending(emp => emp.Age)
            .Select(emp => new { emp.Id, emp.FirstName, emp.LastName, emp.Age })
            .ToList();

        Console.WriteLine("Отсортировать сотрудников по возрасту по убыванию:");
        foreach (var employee in sortedEmployeesByAge)
        {
            Console.WriteLine($"Id: {employee.Id}, Имя: {employee.FirstName}, Фамилия: {employee.LastName}, Возраст: {employee.Age}");
        }
        Console.WriteLine();


        var ageGroups = employees
            .GroupBy(emp => emp.Age)
            .Select(group => new { Age = group.Key, Count = group.Count() })
            .ToList();

        Console.WriteLine("Сгруппировать сотрудников по возрасту и вывести количество сотрудников для каждого возраста:");
        foreach (var ageGroup in ageGroups)
        {
            Console.WriteLine($"Возраст: {ageGroup.Age}, Количество: {ageGroup.Count}");
        }
        Console.WriteLine();

    }
}