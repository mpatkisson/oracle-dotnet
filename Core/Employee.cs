using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Core
{
    public class Employee
    {
        [Key]
        [Column("EMPLOYEE_ID")]
        public int ID { get; set; }

        [Column("LAST_NAME")]
        public string LastName { get; set; }

        [Column("FIRST_NAME")]
        public string FirstName { get; set; }

        public override string ToString()
        {
            return LastName + ", " + FirstName + " - " + ID;
        }
    }
}
