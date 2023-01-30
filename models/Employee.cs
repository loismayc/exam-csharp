namespace Exam.Models
{
    public class Employee : Person
    {
        public string EmployeeNumber { get; set; }
        public float BaseSalary { get; set; }

        public Employee(int id, string firstName, string lastName, string employeeNumber, float baseSalary)
        : base(id, firstName, lastName)
        {
            EmployeeNumber = employeeNumber;
            BaseSalary = baseSalary;
        }

        public float GetSalary()
        {
            return BaseSalary;
        }

        public void DisplayEmployee()
        {
            Console.WriteLine($"Employee Number: {EmployeeNumber} \nName: {FirstName} {LastName}");

        }

        public static explicit operator Employee(int v)
        {
            throw new NotImplementedException();
        }
    }
}