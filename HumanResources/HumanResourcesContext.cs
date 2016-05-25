using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources
{
    public class HumanResourcesContext : DbContext
    {

        public HumanResourcesContext()
            : base()
        {
            Database.SetInitializer<HumanResourcesContext>(null);
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HR");
            modelBuilder.Entity<Employee>().ToTable("EMPLOYEES");
            modelBuilder.Entity<Employee>().HasKey<int>(x => x.ID);
            modelBuilder.Entity<Employee>().Property(x => x.ID).HasColumnName("EMPLOYEE_ID");
            modelBuilder.Entity<Employee>().Property(x => x.FirstName).HasColumnName("FIRST_NAME");
            modelBuilder.Entity<Employee>().Property(x => x.LastName).HasColumnName("LAST_NAME");
            base.OnModelCreating(modelBuilder);
        }
    }
}
