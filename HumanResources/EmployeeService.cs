using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources
{
    public class EmployeeService
    {
        private HumanResourcesContext _context;

        public EmployeeService(HumanResourcesContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            string sql = @"select EMPLOYEE_ID ID
                                 ,LAST_NAME LastName
                                 ,FIRST_NAME FirstName
                           from EMPLOYEES
                           order by LAST_NAME, FIRST_NAME";
            return _context.Database.SqlQuery<Employee>(sql).ToList();
        }
    }
}
