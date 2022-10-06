/**
 * Title:            BlazorApiProject
 * class:			 EmployeeControler.cs
 * Author:           Dominik Bregovic
 * Email:            dominik.bregovic@edu.fh-joanneum.at
 * Semester:         4
 * Last Change:      06.10.2022
 * Description:      Here we define our Api Methods and provide some dummy data
 */

using Microsoft.AspNetCore.Mvc;
using MyModels.Models;

namespace MyAPI.Controllers
{   // This Route is like a adress to our api-data
    [Route("api/")] 
    [ApiController]                
    public class EmployeeController : ControllerBase
    {

        //Normaly we would make DB calls but for this program data-dummy will suffice.
        // the Model is giving as the Template for the Employee Obj
        public static List<Employee> employees = new List<Employee> 
         {
             new Employee
             {
                    Index = 1,
                    EmpId = 1,
                    Name = "Johan"
             },

            new Employee
             {
                   Index = 2,
                   EmpId = 2,
                   Name = "Maria"
             },

            new Employee
            {
                    Index = 3,
                    EmpId = 3,
                    Name = "Nina"
            },

            new Employee
            {
                    Index = 4,
                    EmpId = 4,
                    Name = "Dominik"
             }
         };



        [HttpGet]
        [Route("employee")]
        public IActionResult GetEmployee()
        {
            return Ok(employees);
        }


        [HttpGet]
        [Route("employee/{id}")]
        public IActionResult GetSingelEmployee(int id)
        {

            if (employees.Any(i => i.EmpId == id))
            {
                return Ok(employees.FirstOrDefault(i => i.EmpId == id));
            }
            else
            {
                return NotFound("NO Employee under this ID: " + id);
            }
        }

       
        [HttpDelete]
        [Route("employee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {

            if (employees.Any(i => i.Index == id))
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


        [HttpPost]
        [Route("employee")]
        public IActionResult CreateEmployee(Employee e)
        {

            if (!employees.Any(i => i.Index == e.EmpId))
            {

                int index = employees.Count;
                e.Index = index;
                employees.Add(e);
                return Ok(employees[index]);
            }
            else
            {
                throw new Exception("Id already exists. Choose anothoer one");
            }
        }

 
        [HttpPut]
        [Route("employee/{id}")]
        public IActionResult UpdateEmployee(int id, Employee e)
        {

            if (employees.Any(i => i.Index == id))
            {
                if (employees.Any(i => i.EmpId != e.EmpId))
                {
                    employees[id - 1] = e;
                    return Ok(employees[id - 1]);
                }
                else 
                {
                    throw new Exception("Id already exists");
                }
                
            }
            else
            {
                throw new Exception("no update possible");
            }
        }
    }
}
