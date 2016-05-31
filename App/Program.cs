using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HumanResources.Core;
using HumanResources.EntityFramework;

namespace HumanResources.App
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeService service = new EmployeeService();
            IList<Employee> employees = service.GetAll();
            PrintEmployees(employees);
        }

        /// <summary>
        /// Prints a list of employees to the console.
        /// </summary>
        public static void PrintEmployees(IList<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
