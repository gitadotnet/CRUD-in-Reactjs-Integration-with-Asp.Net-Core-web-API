using Microsoft.EntityFrameworkCore;

namespace AspCoreAPI01_CURD.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {                
        }
        public DbSet<Employee> Employees { get; set; }
        

    }
}
