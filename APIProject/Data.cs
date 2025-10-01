using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options) { }

        public DbSet<Employee> Employees { get; set;}


    }
}
