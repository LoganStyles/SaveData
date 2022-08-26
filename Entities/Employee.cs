namespace SaveData
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
