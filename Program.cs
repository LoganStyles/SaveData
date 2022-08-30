using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var disconnectedEmployee = new Employee
        {
            FirstName = "Kim",
            LastName = "Bale",
            Age = 57
        };
        Update(disconnectedEmployee);

    }

    public static void Update(Employee employee)
    {

        var context = new ArtistsContext();
        context.Employees.Update(employee);
        context.SaveChanges();
    }
}