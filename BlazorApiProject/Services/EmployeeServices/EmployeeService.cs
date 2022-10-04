using System.Xml.Linq;
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
            var result = await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee/GetEmployee");

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
            var result = await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/GetSingelEmployee/{id}");

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
             var result = await _httpClient.DeleteAsync($"api/Employee/DeleteEmployee/{id}");
            
            if (result != null)
            {
                Console.WriteLine("suceesss//////////////////////////////////////////////" + result.ToString);
            }
            else
            {
                throw new Exception("Delet process failed!");
            }
        }

        public async Task CreateEmployee(Employee e)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employee/CreateEmployee",e);
            Console.WriteLine("Result of my Post call ///////////////////////////////////////////");
            Console.WriteLine(result);
        }



        public async Task UpdateEmployee(int empId, Employee e)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Employee/UpdateEmployee/{empId}", e);
            Console.WriteLine("Result of my put call ///////////////////////////////////////////");
            Console.WriteLine(result);
        }

       
    }
}
