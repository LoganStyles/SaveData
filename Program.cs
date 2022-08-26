using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var context = new ArtistsContext();

        //create a new employee
        var employee = new Employee{FirstName="Luke", LastName="Sheldon", Age=18};
        context.Employees.Add(employee);

        context.ChangeTracker.DetectChanges();
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        //save all changes made in this context to the database
        context.SaveChanges();
    }
}