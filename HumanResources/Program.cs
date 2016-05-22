using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources
{
    class Program
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["HumanResources"].ConnectionString;

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
            using (OracleConnection connection = new OracleConnection(_connectionString))
            using (OracleCommand command = new OracleCommand())
            {
                OracleDataReader reader = null;
                try
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * " +
                                          "from EMPLOYEES " +
                                          "order by LAST_NAME";
                    command.Connection = connection;
                    connection.Open();
                    reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("EMPLOYEE_ID")),
                            LastName = reader.GetString(reader.GetOrdinal("LAST_NAME")),
                            FirstName = reader.GetString(reader.GetOrdinal("FIRST_NAME"))
                        });
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
            }
            return employees;
        }
    }
}
