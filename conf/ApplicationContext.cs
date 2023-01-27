using Exam.Models;

namespace Exam.Conf
{
    public class ApplicationContext
    {
        private List<Employee> employees;
        //  private List<SalesEmployee> salesEmployees;


        private static ApplicationContext instance = null;

        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }

        public ApplicationContext()
        {
            this.employees = new List<Employee>();
        }

        public List<Employee> GetEmployees()
        {
            return this.employees;
        }
    }
}