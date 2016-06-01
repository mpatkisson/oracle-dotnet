using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Oracle
{
    /// <summary>
    /// Maps an entity onto an Oracle table.
    /// </summary>
    public abstract class Map<TEntity>
    {
        public abstract string Table { get; }

        public virtual string DefaultOrderingClause { get; }

    }
}
