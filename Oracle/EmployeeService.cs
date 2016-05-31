using HumanResources.Core;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Oracle
{
    public class EmployeeService
    {

        /// <summary>
        /// Gets a new connection associated with the data store.
        /// </summary>
        /// <returns>A newly instantiated connection.</returns>
        public DbConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["HumanResourcesContext"].ConnectionString;
            return new OracleConnection(cs);
        }

        public IList<Employee> GetAll()
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
