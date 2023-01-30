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
        this.GetAll().Remove(e);
    }

    public List<Employee> GetAll()
    {
        return this.employees;
    }

    public List<Employee> GetAllSalesEmployees()
    {
        return this.GetAll().OfType<SalesEmployee>().Cast<Employee>().ToList();

    }

    public List<Employee> GetAllNormalEmployees()
    {
        return this.GetAll().Where(employee => !(employee is SalesEmployee)).ToList();
    }

    public Employee Save(Employee e)
    {
        employees.Add(e);
        return e;
    }

}
