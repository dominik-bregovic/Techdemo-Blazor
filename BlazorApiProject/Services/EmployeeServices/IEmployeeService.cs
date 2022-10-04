using MyModels.Models;

namespace BlazorApiProject.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployee();

        Task<Employee> GetSingelEmployee(int id);

        Task DeleteEmployee(int id);

        Task CreateEmployee(Employee e);

        Task UpdateEmployee(int id, Employee e);
    }
}
