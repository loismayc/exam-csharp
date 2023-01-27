using Exam.Models;
using Exam.Interfaces;
using Exam.Conf;

namespace Exam.Services;
public class EmployeeService : IEmployeeService
{
    private ApplicationContext context;
    private List<Employee> employees;


    public EmployeeService()
    {
        context = ApplicationContext.Instance;
        employees = context.GetEmployees();
    }

    public void AddSale(SalesEmployee e, Sale s)
    {
        e.Sales.Add(s);
    }

    public void Delete(Employee e)
    {
        Employee employeeMatch = employees.SingleOrDefault(x => x.Id == e.Id);
        employees.Remove(employeeMatch);
    }

    public List<Employee> GetAll()
    {
        return this.employees;
    }

    public List<Employee> GetAllSalesEmployees()
    {
        return employees.Where(e => e is SalesEmployee).Select(se => (Employee)se).ToList();


    }

    public Employee Save(Employee e)
    {
        employees.Add(e);
        return e;
    }

}
