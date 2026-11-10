namespace ADO.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string City { get; set; } = string.Empty;
        public DateTime JoinedOn { get; set; }
    }
}