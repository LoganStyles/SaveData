using SaveData.Models.Data;
using SaveData.Models.Entities;

class Program
{

    
    public static void Main(string[] args)
    {

        var context = new SchoolContext();

        //insert departments and instructors
        var computerScience = new Department
        {

            Title = "Computer Science",
            HOD = "Fraser Jones",
            Instructors = new List<Instructor>{
                new Instructor { FirstName="blessing", LastName="Udoh"},
                new Instructor { FirstName="Coleman", LastName="Bale"}
            }

        };

        var businessManagement = new Department
        {

            Title = "Business Management",
            HOD = "Jennifer Rock",
            Instructors = new List<Instructor>{
                new Instructor { FirstName="Benedict", LastName="Okon"}
            }

        };

        var lawScience = new Department
        {
            Title = "Law Science",
            HOD = "Philip Riddick",
            Instructors = new List<Instructor>{
                new Instructor { FirstName="karim", LastName="balogun"}
            }
        };

        //track Department entity and any other reachable entities
        context.Departments.Add(computerScience);
        context.Departments.Add(businessManagement);
        context.Departments.Add(lawScience);

        //save departments & instructors
        context.SaveChanges();

        // insert courses
        var infoSys = new Course { Title = "Information Systems", DepartmentCode = 1 };
        var swe = new Course { Title = "Software Engineering", DepartmentCode = 1 };
        var busLeadership = new Course { Title = "Business Leadership", DepartmentCode = 2 };
        var digiBusiness = new Course { Title = "Digital Business", DepartmentCode = 2 };

        // add courses to the context
        context.Courses.Add(infoSys);
        context.Courses.Add(swe);
        context.Courses.Add(busLeadership);
        context.Courses.Add(digiBusiness);

        //save the courses
        context.SaveChanges();

        //Insert students with their related courses
        //Note: After the last SaveChanges() operation, the saved course Ids exist in the context.
        var ferdinand = new Student
        {
            FirstName = "Ferdinand",
            LastName = "Mbotidem",
            DepartmentCode = 1,
            StudentCourses = new List<StudentCourse>{
                new StudentCourse{CourseId = infoSys.Id}
            }
        };

        var margaret = new Student
        {
            FirstName = "Margaret",
            LastName = "Olorunisola",
            DepartmentCode = 2,
            StudentCourses = new List<StudentCourse>{
                new StudentCourse {CourseId=busLeadership.Id},
                new StudentCourse {CourseId=digiBusiness.Id}
            }
        };

        //add students to the context
        context.Students.Add(ferdinand);
        context.Students.Add(margaret);

        //save students
        context.SaveChanges();

        //delete the law science department & related instructors
        context.Departments.Remove(lawScience);
        context.SaveChanges();

        //fetch & display data
        Console.WriteLine("---DEPARTMENTS---");
        Console.WriteLine("TITLE \t\t\tHOD");
        var departments = context.Departments.ToList();

        foreach (var department in departments)
        {
            Console.WriteLine("{0} \t{1}", department.Title, department.HOD);
        }


        Console.WriteLine("\n---INSTRUCTORS---");
        Console.WriteLine("FIRSTNAME \tLASTNAME \tDEPARTMENT");
        var instructors = context.Instructors.ToList();

        foreach (var instructor in instructors)
        {
            Console.WriteLine($"{instructor.FirstName} \t{instructor.LastName} \t\t{instructor.Department.Title}");
        }

        Console.WriteLine("\n---COURSES---");
        Console.WriteLine("TITLE \t\t\tDEPARTMENT");
        var courses = context.Courses
        .Join(context.Departments, co => co.DepartmentCode, dept => dept.Id,
        (cos, depts) => new
        {
            Title = cos.Title,
            DepartmentTitle = depts.Title
        });

        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Title} \t{course.DepartmentTitle}");
        }

        Console.WriteLine("\n---STUDENTS---");
        Console.WriteLine("FIRSTNAME \tLASTNAME \tDEPARTMENT");
        var students = context.Students
        .Join(context.Departments, stud => stud.DepartmentCode, dept => dept.Id,
        (studs, depts) => new
        {
            FirstName = studs.FirstName,
            LastName = studs.LastName,
            Department = depts.Title
        });

        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} \t{student.LastName} \t{student.Department}");
        }

        
    }
}