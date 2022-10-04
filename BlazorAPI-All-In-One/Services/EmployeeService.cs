using BlazorAPI_All_In_One.Models;

namespace BlazorAPI_All_In_One.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee/GetEmployees");
        }
    }
}
