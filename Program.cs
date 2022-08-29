using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var disconnectedEmployee = new Employee { Id = 4, FirstName = "Femi", LastName = "Landon", Age = 34 };
        var context = new ArtistsContext();

        //check its state
        Console.WriteLine("Employee {0} is in {1} state", 
        disconnectedEmployee.FirstName, 
        context.Entry(disconnectedEmployee).State);

        //save all changes made in this context to the database
        context.SaveChanges();
    }
}