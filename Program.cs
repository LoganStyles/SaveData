using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var context = new ArtistsContext();

        //fetch the first employee from the employees table
        var employee = context.Employees.FirstOrDefault();
        context.Employees.Remove(employee);

        context.ChangeTracker.DetectChanges();
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);

        //save all changes made in this context to the database
        context.SaveChanges();
    }
}