﻿using SaveData;

class Program
{

    public static void Main(string[] args)
    {

        var disconnectedEmployee = new Employee
        {
            FirstName = "Femi",
            LastName = "Balogun",
            Age = 34
        };
        Insert(disconnectedEmployee);

    }

    public static void Insert(Employee employee)
    {

        using var context = new ArtistsContext();
        context.Employees.Add(employee);
        context.SaveChanges();
    }
}