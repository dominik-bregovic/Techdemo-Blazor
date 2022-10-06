/**
 * Title:            BlazorApiProject
 * class:			 EmployeeService.cs
 * Author:           Dominik Bregovic
 * Email:            dominik.bregovic@edu.fh-joanneum.at
 * Semester:         4
 * Last Change:      06.10.2022
 * Description:      Here we call our api and check the results of the call.
 */


using MyModels.Models;

namespace BlazorApiProject.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       

        public async Task<List<Employee>> GetEmployee()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Employee>>("api/employee");

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Staff or Employees not found!");
            }
        }
        public async Task<Employee> GetSingelEmployee(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Employee not found!");
            }

        }

        public async Task DeleteEmployee(int id)
        {
             var result = await _httpClient.DeleteAsync($"api/employee/{id}");
            
            if (result != null)
            {
                Console.WriteLine("---suceesss---" + result.ToString);
            }
            else
            {
                throw new Exception("Delete process failed!");
            }
        }

        public async Task CreateEmployee(Employee e)
        {
            var result = await _httpClient.PostAsJsonAsync("api/employee",e);
            if (result != null)
            {
                Console.WriteLine("---suceesss---" + result.ToString);
            }
            else
            {
                throw new Exception("Creation process failed!");
            }
        }



        public async Task UpdateEmployee(int index, Employee e)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/employee/{index}", e);
            if (result != null)
            {
                Console.WriteLine("---suceesss---" + result.ToString);
            }
            else
            {
                //throw new Exception("Update process failed!");
            }
        }

       
    }
}
