using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        using var context = new ArtistsContext();

        //create new instance of employee
        var employee = new Employee { FirstName = "Susan", LastName = "Fred", Age = 28 };

        //begin tracking the Employee entity
        context.Employees.Add(employee);
        // context.Add<Employee>(employee);
        //save all changes made in this context to the database
        context.SaveChanges();

        var allEmployees = context.Employees.ToList();
        Console.WriteLine("Id \tFirstName \tLastName \tAge");
        foreach (var emp in allEmployees)
        {
            Console.WriteLine($"{emp.Id}\t{emp.FirstName}\t\t{emp.LastName}\t\t{emp.Age}");
        }
    }
}