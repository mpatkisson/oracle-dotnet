using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace HumanResources
{
    class Program
    {

        static void Main(string[] args)
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                EmployeeService service = new EmployeeService(context);
                List<Employee> employees = service.GetAll();
                PrintEmployees(employees);
            }
        }

        /// <summary>
        /// Prints a list of employees to the console.
        /// </summary>
        static void PrintEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

    }
}
