using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        }

        private IList<Employee> GetEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            using (OracleConnection connection = new OracleConnection())
            using (OracleCommand command = new OracleCommand())
            {
                
            }
            return employees;
        }
    }
}
