using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HumanResources.Core;

namespace HumanResources.EntityFramework
{
    public class EmployeeService
    {

        public List<Employee> GetAll()
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                string sql = @"select EMPLOYEE_ID
                                 ,LAST_NAME
                                 ,FIRST_NAME
                           from EMPLOYEES
                           order by LAST_NAME, FIRST_NAME";
                return context.Database.SqlQuery<Employee>(sql).ToList();
            }
        }
    }
}
