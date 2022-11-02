namespace SaveData.Models.Entities
{

    public class Instructor
    {

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public long DepartmentCode { get; set; }
        public Department Department { get; set; }

    }
}