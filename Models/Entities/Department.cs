namespace SaveData.Models.Entities{

    public class Department{

        public long Id { get; set; }
        public string Title { get; set; }
        public string HOD { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}