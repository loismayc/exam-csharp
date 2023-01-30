namespace Exam.Models
{
    public class SalesEmployee : Employee
    {
        public float Commission { get; set; }
        public List<Sale> Sales { get; set; }

        public SalesEmployee(int id, string firstName, string lastName, string employeeNumber, float baseSalary, float commission)
        : base(id, firstName, lastName, employeeNumber, baseSalary)
        {
            Commission = commission;
            Sales = new List<Sale>();

        }

        public float GetSalary()
        {
            float totalSales = Sales.Sum(s => s.Amount);
            return BaseSalary + Commission * totalSales;
        }

        public List<Sale> GetSales()
        {
            return this.Sales;
        }
    }
}