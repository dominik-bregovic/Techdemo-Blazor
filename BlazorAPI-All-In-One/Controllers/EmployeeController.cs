using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorAPI_All_In_One.Models;

namespace BlazorAPI_All_In_One.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        // Defining out Api - Get Method
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee();
            employee.EmpId = 1;
            employee.Name = "Johan";
            employees.Add(employee);

            employee = new Employee();
            employee.EmpId = 2;
            employee.Name = "Maria";
            employees.Add(employee);

            employee = new Employee();
            employee.EmpId = 3;
            employee.Name = "Nina";
            employees.Add(employee);

            employee = new Employee();
            employee.EmpId = 4;
            employee.Name = "Tom";
            employees.Add(employee);


            return Ok(employees);
        }
    }
}
