using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var addDisconnectedEmployee = new Employee
        {
            FirstName = "Femi",
            LastName = "Balogun",
            Age = 34
        };
        Update(addDisconnectedEmployee);

        var updateDisconnectedEmployee = new Employee
        {
            Id = 2,
            FirstName = "Kim",
            LastName = "James",
            Age = 34
        };
        Update(updateDisconnectedEmployee);

    }

    public static void Update(Employee employee)
    {

        using var context = new ArtistsContext();
        context.Employees.Update(employee);
        context.SaveChanges();
    }
}