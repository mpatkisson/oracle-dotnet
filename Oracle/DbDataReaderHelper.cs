using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Oracle
{
    public static class DbDataReaderHelper
    {

        public static T GetValue<T>(this DbDataReader reader, string columnName)
        {
            return (T)reader[columnName];
        }

    }
}
