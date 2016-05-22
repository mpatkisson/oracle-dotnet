using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

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
        /// Gets a new connection associated with the data store.
        /// </summary>
        /// <returns>A newly instantiated connection.</returns>
        public DbConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["HumanResources"].ConnectionString;
            return new OracleConnection(cs);
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
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * " +
                                      "from EMPLOYEES " +
                                      "order by LAST_NAME";
                command.Connection = connection;
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("EMPLOYEE_ID")),
                            LastName = reader.GetString(reader.GetOrdinal("LAST_NAME")),
                            FirstName = reader.GetString(reader.GetOrdinal("FIRST_NAME"))
                        });
                    }
                }
            }
            return employees;
        }
    }
}
