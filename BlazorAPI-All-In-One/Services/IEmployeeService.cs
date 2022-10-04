using BlazorAPI_All_In_One.Models;

namespace BlazorAPI_All_In_One.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
    }
}
