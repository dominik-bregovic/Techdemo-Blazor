using Microsoft.AspNetCore.Mvc;
using MyModels.Models;

namespace MyAPI.Controllers
{                               // This Route is like a adress to our api-data
    [Route("api/[controller]")] //the [controller] stands for everything befor "......Controller : ControllerBase", like Employee in our case
    [ApiController]                
    public class EmployeeController : ControllerBase
    {

         public static List<Employee> employees = new List<Employee> 
         {
             new Employee
             {
                    EmpId = 1,
                    Name = "Johan"
             },

            new Employee
             {
                   EmpId = 2,
                   Name = "Maria"
             },

            new Employee
            {
                    EmpId = 3,
                    Name = "Nina"
            },

            new Employee
            {   
                    EmpId = 4,
                    Name = "Dominik"
             }
         };



        // Defining out Api - Get Method
        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult GetEmployee()
        {
           
            //Normaly we would make a DB call but for now we are creating Employees and assign values to them.
            // the Model is giving as the Template for the Employee Obj

            return Ok(employees);

        }



        // Defining out Api - Get Single Method
        [HttpGet]
        [Route("GetSingelEmployee/{id}")]
        public IActionResult GetSingelEmployee(int id)
        {

            //Normaly we would make a DB call but for now we are creating Employees and assign values to them.
            // the Model is giving as the Template for the Employee Obj

            if (employees.Any(i => i.EmpId == id))
            {
                return Ok(employees.FirstOrDefault(i => i.EmpId == id));
            }
            else
            {
                return NotFound("NO Employee under this ID: " + id);
            }
        }

        // Defining out Api - Delete Single Employee Method
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {

            //Normaly we would make a DB call but for now we are creating Employees and assign values to them.
            // the Model is giving as the Template for the Employee Obj

            if (employees.Any(i => i.EmpId == id))
            {
                int length = employees.Count;

                employees.RemoveAt(id-1);
                return Ok(employees.Count < length);
            }
            else
            {
                return NotFound("No Employee with this ID: " + id);
            }
        }





        // Defining out Api - Create Single Employee Method
        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee(Employee e)
        {

            //Normaly we would make a DB call but for now we are creating Employees and assign values to them.
            // the Model is giving as the Template for the Employee Obj
            Console.WriteLine("trying to add new params ////////////////////////////////");

            if (!employees.Any(i => i.EmpId == e.EmpId))
            {
                int index = employees.Count;
                Console.WriteLine("Adding params/////////////");
                employees.Add(e);
                return Ok(employees[index]);
            }
            else
            {
                //return BadRequest("\"Id already exists. Choose anothoer one\"");     // Code: 400
                throw new Exception("Id already exists. Choose anothoer one");
            }
        }

        // Defining out Api - Update Single Employee Method
        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, Employee e)
        {
            
            //Normaly we would make a DB call but for now we are creating Employees and assign values to them.
            // the Model is giving as the Template for the Employee Obj
             Console.WriteLine("trying to add new params ////////////////////////////////");

            if (employees.Any(i => i.EmpId == id))
            {
                Console.WriteLine("Adding params/////////////");
                employees[id-1] = e;
                return Ok(employees[id]);
            }
            else
            {
                //return NotFound("No update possible, No user found");       //Code: 404
                throw new Exception("no update possible");
            }
        }
    }
}
