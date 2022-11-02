using SaveData.Models.Data;
using SaveData.Models.Entities;

class Program
{

    public static void Main(string[] args)
    {

        //save the following data into the database
        //DEPARTMENTS
        //1,'Engineering','Fraser Jones'
        //2,'Computer Science','Campbell rock'
        /* 
        INSTRUCTORS
        blessing udoh,1
        martin jeffries, 2
        coleman bale,1

        STUDENTS
        Ferdinand, joe, 1
        Regina, Queen, 2
        Chiwendu, Felix, 2

        COURSES

        maths, 1
        english, 2

         */

        var context = new SchoolContext();

        var engineeringDepartment = new Department
        {

            Title = "Chemical Engineering",
            HOD = "Fraser Jones",
            Instructors = new List<Instructor>{
                new Instructor { FirstName="blessing", LastName="Udoh"},
                new Instructor { FirstName="Coleman", LastName="Bale"}
            }

        };

        var compSciDepartment = new Department
        {

            Title = "Computer Science",
            HOD = "Campbell Rock",
            Instructors = new List<Instructor>{
                new Instructor { FirstName="martin", LastName="jeffrey"}
            }

        };

        /*begin tracking the Department entity and 
                any other reachable entities
                */
        context.Departments.Add(engineeringDepartment);
        context.Departments.Add(compSciDepartment);

        //courses
        var maths = new Course { Title = "Maths", DepartmentCode = 1 };
        var english = new Course { Title = "English", DepartmentCode = 2 };
        var chemistry = new Course { Title = "Chemistry", DepartmentCode = 2 };

        context.Courses.Add(maths);
        context.Courses.Add(english);
        context.Courses.Add(chemistry);

        //students
        var faith = new Student
        {
            FirstName = "Faith",
            LastName = "Mbotidem",
            DepartmentCode = 1,
            StudentCourses = new List<StudentCourse>{
                new StudentCourse{CourseId = maths.Id}
            }
        };

        var martha = new Student
        {
            FirstName = "Martha",
            LastName = "Joel",
            DepartmentCode = 2,
            StudentCourses = new List<StudentCourse>{
                new StudentCourse {CourseId=english.Id},
                new StudentCourse {CourseId=chemistry.Id}
            }
        };

        context.Students.Add(faith);
        context.Students.Add(martha);

        //student courses
        // var faithStudentId = context.Students.SingleOrDefault(stud => stud.LastName.Equals(faith.LastName)).Id;

        // var faithCourses = ;

        // var marthaCourses = new StudentCourse
        // {
        //     StudentId = martha.Id,
        //     CourseId = chemistry.Id
        // };

        // context.StudentCourses.Add(faithCourses);
        // context.StudentCourses.Add(marthaCourses);

        //save all changes made in this context to the database
        context.SaveChanges();

        //fetch & display data
        var departments = context.Departments.ToList();
        Console.WriteLine("DEPARTMENTS \tHOD");

        foreach (var department in departments)
        {
            Console.WriteLine("{0} \t{1}", department.Title, department.HOD);
        }


        var instructors = context.Instructors.ToList();
        Console.WriteLine("FIRSTNAME \tLASTNAME \tDEPARTMENT");

        foreach (var instructor in instructors)
        {
            Console.WriteLine($"{instructor.FirstName} \t{instructor.LastName} \t{instructor.Department.Title}");
        }

        var students = context.Students
                    .Join(context.Departments, stud => stud.DepartmentCode, dept => dept.Id, (studs, depts) => new
                    {
                        FirstName = studs.FirstName,
                        LastName = studs.LastName,
                        Department = depts.Title
                    });
        Console.WriteLine("FIRSTNAME \tLASTNAME \tDEPARTMENT");

        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} \t{student.LastName} \t{student.Department}");
        }
    }
}