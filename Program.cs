using Exam.Conf;
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
                    if (employeeList.Count > 0)
                    {
                        Console.WriteLine("List of employees: ");
                        for (int i = 0; i < employeeList.Count; i++)
                        {
                            Employee eList = employeeList[i];
                            Console.WriteLine($"\nEmployee Number: {eList.EmployeeNumber}");
                            Console.WriteLine($"Name: {eList.FirstName} {eList.LastName}");
                            Console.WriteLine($"Base Salary: {eList.BaseSalary} ");

                        }
                    }
                    else
                    {
                        Console.WriteLine("List is empty");
                    }
                }
                else if (choice == 2) //save
                {
                    Console.WriteLine("Regular employee or Sales employee? R/S");
                    string enter = Console.ReadLine().ToLower();

                    Console.Write("Enter first name of employee: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter last name of employee: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter employee number: ");
                    string employeeNum = Console.ReadLine();
                    Console.Write("Enter base salary: ");
                    float baseSalary = float.Parse(Console.ReadLine());

                    if (enter == "r")
                    {
                        int id = employeeList.Count + 1;
                        Employee eInfo = new Employee(id, firstName, lastName, employeeNum, baseSalary);
                        eInfo = employeeService.Save(eInfo);
                    }
                    else if (enter == "s")
                    {
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
                    Console.WriteLine("Employee Saved!");

                }
                else if (choice == 3) // delete
                {
                    Console.WriteLine("Enter employee's first name:");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Enter employee's last name:");
                    var lastName = Console.ReadLine();

                    var employee = employeeService.GetAll().FirstOrDefault(e => e.FirstName == firstName && e.LastName == lastName);
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
                    float sEmpID = float.Parse(Console.ReadLine());
                    var salesEmployeeId = employeeService.GetAllSalesEmployees().FirstOrDefault(e => e.Id == sEmpID);
                    // SalesEmployee salesEmp = (SalesEmployee)employeeService.GetAllSalesEmployees().SingleOrDefault(x => x.Id == sEmpID);

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
                }
                else
                {
                    Console.WriteLine("You have entered an invalid choice");
                }

            }

        }

        // public static Employee FindItem(Employee empId, int id)
        // {
        //     Employee item = employeeService.FindById(empId.Id, id);

        //     if (item == null)
        //     {
        //         Console.WriteLine($"ERROR. Item ID {id} is Invalid.");
        //     }

        //     return item;
        // }

    }
}