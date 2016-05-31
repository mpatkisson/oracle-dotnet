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
                    employees = ToEntities(reader);
                }
            }
            return employees;
        }

        protected IList<Employee> ToEntities(DbDataReader reader)
        {
            List<Employee> employees = new List<Employee>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Employee employee = ToEntity(reader);
                    employees.Add(employee);
                }
            }
            return employees;
        }

        protected Employee ToEntity(DbDataReader reader)
        {
            return new Employee
            {
                ID = reader.GetValue<int>("EMPLOYEE_ID"),
                LastName = reader.GetValue<string>("LAST_NAME"),
                FirstName = reader.GetValue<string>("FIRST_NAME")
            };
        }
    }
}
