
using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var context = new ArtistsContext();

        //create new graph of employee together with albums
        var employee = new Employee
        {
            FirstName = "Steven",
            LastName = "Brandy",
            Age = 30,
            Albums = new List<Album>{

                new Album { Title="Lovely skys", Price=2500},
                new Album { Title="Joy of the sun", Price=4000},

            }
        };

        /*begin tracking the Employee entity and 
        any other reachable entities that are not being tracked
        */
        context.Employees.Add(employee);
        //save all changes made in this context to the database
        context.SaveChanges();

        //display all employees and albums
        var allEmployees = context.Employees.ToList();
        Console.WriteLine("Id \tFirstName \tLastName \tAge");
        foreach (var emp in allEmployees)
        {
            Console.WriteLine($"{emp.Id}\t{emp.FirstName}\t\t{emp.LastName}\t\t{emp.Age}");
        }
        
        var allAlbums = context.Albums.ToList();
        Console.WriteLine("Id \tTitle \t\t\tPrice \tEmployeeId");
        foreach (var alb in allAlbums)
        {
            Console.WriteLine($"{alb.Id}\t{alb.Title}\t\t{alb.Price}\t\t{alb.EmployeeId}");
        }
    }
}