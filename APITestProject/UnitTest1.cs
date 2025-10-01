using APIProject;
using APIProject.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace APITestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1==1);

        }

        [Fact]
        public void Test2()
        {
            
            
            Assert.True(VerifyTest.checkTest() == 5);

        }

        [Fact]
        public async Task EmployeeIntegrationCheck()
        {


            //Create db context
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var context = new EmployeeContext(optionsBuilder.Options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            //delete all employees
            context.Employees.RemoveRange(await context.Employees.ToArrayAsync());
            await context.SaveChangesAsync();
            //Create Controller
            var controller = new EmployeesController(context);
            //Add Employee
            await controller.Add(new Employee() { Name = "Emp1" });
            //Check Getall
            var result = (await controller.GetAll()).ToArray();
            Assert.Single(result);
            Assert.Equal("Emp1", result[0].Name);


        }
    }
}