using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var disconnectedEmployee = new Employee
        {
            Id = 2,
            FirstName = "Desmond",
            LastName = "Paul",
            Age = 23,
            Albums = new List<Album>(){
                new Album{ Title="Gone with the wind",Price=7000},
                new Album{ Title="Pink roses", Price=2800}
            }
        };
        UpdateExistingEmployees(disconnectedEmployee);

    }

    public static void UpdateExistingEmployees(Employee employee)
    {

        using var context = new ArtistsContext();
        context.Employees.Update(employee);
        context.SaveChanges();
    }
}