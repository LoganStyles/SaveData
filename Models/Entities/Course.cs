namespace SaveData.Models.Entities
{

    public class Course
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public long DepartmentCode { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}