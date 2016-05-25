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
            Program program = new Program();
            program.PrintEmployees();
        }

        /// <summary>
        /// Prints a list of employees to the console.
        /// </summary>
        public void PrintEmployees()
        {
            var employees = GetEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.LastName + ", " + employee.FirstName + " " + employee.ID);
            }
        }

        /// <summary>
        /// Gets a list of employees from the database.
        /// </summary>
        /// <returns>A non-null IList of Employees.</returns>
        private IList<Employee> GetEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                var query = from e in context.Employees
                            orderby e.LastName, e.FirstName
                            select e;
                employees = query.ToList();
            }
            return employees;
        }
    }
}
