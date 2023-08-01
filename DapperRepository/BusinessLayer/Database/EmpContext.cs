using DapperRepository.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DapperRepository.BusinessLayer.Database
{
    public class EmpContext:DbContext
    {
        public EmpContext(DbContextOptions<EmpContext>options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }  
    }
}
