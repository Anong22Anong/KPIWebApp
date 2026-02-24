using KpiWebApp.Models;

namespace KpiWebApp.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee> AddAsync(Employee employee);
    Task<Employee> UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
    Task<IEnumerable<Employee>> GetTopByKpiAsync(int count = 5);
}
