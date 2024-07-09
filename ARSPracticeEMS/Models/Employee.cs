namespace ARSPracticeEMS.Models
{
    public class Employee
    {
        public int EmpId {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DeptNo {  get; set; }
        public string EmployeeType {  get; set; }
        public DateTime DateOfJoining { get; set; }
        public Department Dept { get; set; }
    }
}
