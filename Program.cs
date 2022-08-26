using Microsoft.EntityFrameworkCore;
using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var context = new ArtistsContext();

        //create new instance of employee
        var employee = new Employee { FirstName = "Susan", LastName = "Fredricks", Age = 28 };

        //begin tracking the Employee entity
        context.Entry(employee).State = EntityState.Added;
        //save all changes made in this context to the database
        context.SaveChanges();
    }
}