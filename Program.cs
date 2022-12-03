
using SaveData;

class Program{

    public static void Main(string[] args){

        var context = new ArtistsContext();

        //fetch the first employee from the employees table
        var employee = context.Employees.FirstOrDefault();
        employee.FirstName="Mark";

        //save all changes made in this context to the database
        context.SaveChanges();

        //display all employees
        var allEmployees = context.Employees.ToList();
        Console.WriteLine("Id \tFirstName \tLastName \tAge");
        foreach (var emp in allEmployees)
        {
            Console.WriteLine($"{emp.Id}\t{emp.FirstName}\t\t{emp.LastName}\t\t{emp.Age}");
        }
    }
}