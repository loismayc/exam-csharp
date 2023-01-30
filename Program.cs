using Exam.Commands;
using Exam.Models;
using Exam.Interfaces;
using Exam.Services;

namespace Exam
{
    public class Program
    {
        public static IEmployeeService employeeService = new EmployeeService();
        public static void Main(string[] args)
        {
            List<Employee> employeeList = employeeService.GetAll();
            List<Employee> salesEmployeeList = employeeService.GetAllSalesEmployees();

            bool show = true;

            while (show)
            {
                Console.WriteLine("========= MAIN MENU ==========");
                Console.WriteLine("1. List all employees");
                Console.WriteLine("2. Save Employee Record");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Add sale to employee");
                Console.WriteLine("5. Quit");
                Console.WriteLine("\nChoose a number: ");

                float choice = float.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    var normalEmployees = employeeService.GetAllNormalEmployees();
                    var saleEmployees = employeeService.GetAllSalesEmployees().Cast<SalesEmployee>().ToList();

                    if (employeeService.GetAll().Count > 0)
                    {
                        Console.WriteLine("List of all employees:");

                        if (normalEmployees.Count > 0)
                        {
                            Console.WriteLine("\nNormal Employee:");
                            foreach (Employee employee in normalEmployees)
                            {
                                Console.WriteLine("Id: " + employee.Id);
                                Console.WriteLine("Employee #: " + employee.EmployeeNumber);
                                Console.WriteLine("Base salary: " + employee.GetSalary());
                            }
                        }

                        if (saleEmployees.Count > 0)
                        {
                            Console.WriteLine("\nSales Employee:");
                            foreach (SalesEmployee saleEmployee in saleEmployees)
                            {
                                Console.WriteLine("Id: " + saleEmployee.Id);
                                Console.WriteLine("Employee #: " + saleEmployee.EmployeeNumber);
                                Console.WriteLine("Name: " + saleEmployee.FirstName + " " + saleEmployee.LastName);
                                Console.WriteLine("Base salary: " + saleEmployee.GetSalary());
                                Console.WriteLine("Commission: " + saleEmployee.Commission);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Employee list is empty");
                    }
                }
                else if (choice == 2) //save - add id validation 
                {
                    Console.WriteLine("Regular employee or Sales employee? R/S");
                    string enter = Console.ReadLine().ToLower();
                    if (enter == "r")
                    {
                        Console.Write("Enter first name of employee: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter last name of employee: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter employee number: ");
                        string employeeNum = Console.ReadLine();
                        Console.Write("Enter base salary: ");
                        float baseSalary = float.Parse(Console.ReadLine());
                        int id = employeeList.Count + 1;
                        Employee eInfo = new Employee(id, firstName, lastName, employeeNum, baseSalary);
                        eInfo = employeeService.Save(eInfo);
                    }
                    else if (enter == "s")
                    {
                        Console.Write("Enter first name of employee: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter last name of employee: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter employee number: ");
                        string employeeNum = Console.ReadLine();
                        Console.Write("Enter base salary: ");
                        float baseSalary = float.Parse(Console.ReadLine());
                        Console.Write("Enter commission: ");
                        float commission = float.Parse(Console.ReadLine());
                        int sId = salesEmployeeList.Count + 1;
                        SalesEmployee sInfo = new SalesEmployee(sId, firstName, lastName, employeeNum, baseSalary, commission);
                        sInfo = (SalesEmployee)employeeService.Save(sInfo);
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }

                    //  Console.WriteLine("Employee Saved!");

                }
                else if (choice == 3) // delete
                {
                    Console.WriteLine("Enter employee number:");
                    var empId = Console.ReadLine();

                    var employee = employeeService.GetAll().FirstOrDefault(e => e.EmployeeNumber == empId);
                    if (employee != null)
                    {
                        employeeService.Delete(employee);
                        Console.WriteLine("Employee record deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Employee not found.");
                    }


                }
                else if (choice == 4) // add sale 
                {
                    Console.Write("Sales Employee ID: ");
                    var sEmpID = Console.ReadLine();
                    var salesEmployeeId = employeeService.GetAllSalesEmployees().FirstOrDefault(e => e.EmployeeNumber == sEmpID);

                    if (salesEmployeeId != null)
                    {
                        Console.Write("Enter Sale Item Name: ");
                        string itemName = Console.ReadLine();
                        Console.Write("Enter amount of sale item: ");
                        float amount = float.Parse(Console.ReadLine());
                        Sale saleItem = new Sale(itemName, amount);

                        employeeService.AddSale((SalesEmployee)salesEmployeeId, saleItem);

                    }
                    else
                    {
                        Console.WriteLine("Sales employee not found");
                    }
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Bye");
                    show = false;

                    var report = new BuildReport();
                    Console.WriteLine(report.Execute());
                }
                else
                {
                    Console.WriteLine("You have entered an invalid choice");
                }

            }

        }


    }
}