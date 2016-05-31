using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HumanResources.Core;

namespace HumanResources.Oracle
{
    /// <summary>
    /// Maps an employee onto an Oracle table.
    /// </summary>
    public class EmployeeMap : Map<Employee>
    {
        public override string Table
        {
            get
            {
                return "EMPLOYEES";
            }
        }

        public override string DefaultOrderingClause
        {
            get
            {
                return "LAST_NAME, FIRST_NAME";
            }
        }


    }
}
