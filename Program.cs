using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var disconnectedEmployee = new Employee
        {
            Id=3
        };
        Remove(disconnectedEmployee);
    }

    public static void Remove(Employee employee)
    {

        var context = new ArtistsContext();
        context.Employees.Remove(employee);
        context.SaveChanges();
    }
}