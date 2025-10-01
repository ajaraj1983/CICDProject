using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext context;

        

        public EmployeesController(EmployeeContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<IEnumerable<Employee>> GetAll() => await context.Employees.ToArrayAsync();

        [HttpPost(Name = "PostEmployee")]
        public async Task<Employee> Add([FromBody] Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
