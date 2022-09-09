using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var disconnectedEmployee = new Employee
        {
            Id = 2,
            FirstName = "Femi",
            LastName = "Balogun",
            Age = 34
        };
        Update(disconnectedEmployee);
    }

    public static void Update(Employee employee)
    {

        using var context = new ArtistsContext();
        context.Employees.Update(employee);
        context.SaveChanges();
    }
}