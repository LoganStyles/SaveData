
using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var context = new ArtistsContext();

        //create new instance of employee together with albums
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
    }
}