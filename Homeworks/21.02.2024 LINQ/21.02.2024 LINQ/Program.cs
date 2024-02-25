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
            new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
        };
        List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 24, DepId = 2 },
            new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 }
        };


        var studentsWithLocations = employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Age,
                Location = departments
                    .Where(d => d.Id == e.DepId)
                    .Select(d => $"{d.Country}, {d.City}")
                    .FirstOrDefault()
            });

        foreach (var student in studentsWithLocations)
        {
            Console.WriteLine($"Name: {student.FirstName} {student.LastName}, Age: {student.Age}, Location: {student.Location}");
        }

        Console.WriteLine();



        // 1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе.
        var ukraineEmployeesNotInOdesa = employees
            .Where(e => departments.Any(d => d.Id == e.DepId && d.Country == "Ukraine" && d.City != "Odesa"))
            .Select(e => new { e.FirstName, e.LastName });

        //e и d - это алиасы для переменных, представляющих элементы из коллекций employees и departments.


        // employees.Where(e => departments.Any(d => d.Id == e.DepId && d.Country == "Ukraine" && d.City != "Odesa")):

        // employees.Where - это метод LINQ, который фильтрует элементы коллекции employees на основе предоставленного условия.
        // e => departments.Any(d => d.Id == e.DepId && d.Country == "Ukraine" && d.City != "Odesa") - это лямбда - выражение, которое проверяет, что существует хотя бы     один    элемент в коллекции departments, удовлетворяющий условиям:
        // d.Id == e.DepId - идентификатор отдела в коллекции departments равен идентификатору отдела сотрудника из коллекции employees.
        // d.Country == "Ukraine" - страна отдела в коллекции departments равна "Ukraine".
        // d.City != "Odesa" - город отдела в коллекции departments не равен "Odesa".
        // .Select(e => new { e.FirstName, e.LastName }):

        // Select - это метод LINQ, который проецирует(выбирает) определенные свойства объектов в новую структуру.
        // e => new { e.FirstName, e.LastName } - лямбда - выражение, которое создает анонимный объект, содержащий только свойства FirstName и LastName сотрудника.


        Console.WriteLine("1) Имена и фамилии сотрудников, работающих в Украине, но не в Одессе:");
        foreach (var employee in ukraineEmployeesNotInOdesa)
        {
            Console.WriteLine($"   {employee.FirstName} {employee.LastName}");
        }






        //2) Вывести список стран без повторений.
        var uniqueCountries = departments.Select(d => d.Country).Distinct();

        Console.WriteLine("\n2) Список уникальных стран");
        foreach (var country in uniqueCountries)
        {
            Console.WriteLine($"   {country}");
        }







        // 3) Выбрать 3-х первых сотрудников, возраст которых превышает 25 лет.
        var firstThreeOver25 = employees.Where(e => e.Age > 25).Take(3);

        Console.WriteLine("\n3) Три первых сотрудника, возраст которых превышает 25 лет:");
        foreach (var employee in firstThreeOver25)
        {
            Console.WriteLine($"   {employee.FirstName} {employee.LastName}, Возраст: {employee.Age}");
        }






        // 4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года.
        var kyivStudentsOver23 = employees
            .Where(e => departments.Any(d => d.Id == e.DepId && d.City == "Kyiv") && e.Age > 23)
            .Select(e => new { e.FirstName, e.LastName, e.Age });



        Console.WriteLine("\n4) Имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года:");
        foreach (var student in kyivStudentsOver23)
        {
            Console.WriteLine($"   {student.FirstName} {student.LastName}, Возраст: {student.Age}");
        }
    }
}