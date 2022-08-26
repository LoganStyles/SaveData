namespace SaveData
{
    public class Album
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
