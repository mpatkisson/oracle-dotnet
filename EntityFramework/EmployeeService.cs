using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources
{
    public class EmployeeService
    {

        public List<Employee> GetAll()
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                string sql = @"select EMPLOYEE_ID ID
                                 ,LAST_NAME LastName
                                 ,FIRST_NAME FirstName
                           from EMPLOYEES
                           order by LAST_NAME, FIRST_NAME";
                return context.Database.SqlQuery<Employee>(sql).ToList();
            }
        }
    }
}
