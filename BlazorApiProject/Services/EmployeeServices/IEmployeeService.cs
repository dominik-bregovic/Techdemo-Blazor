/**
 * Title:            BlazorApiProject
 * class:			 IEmployeeService.cs
 * Author:           Dominik Bregovic
 * Email:            dominik.bregovic@edu.fh-joanneum.at
 * Semester:         4
 * Last Change:      06.10.2022
 * Description:      Here we define which api-calls have to be implemented.
 */

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
