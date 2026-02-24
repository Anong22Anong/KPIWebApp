using KpiWebApp.Models;

namespace KpiWebApp.Services;

public interface IKpiService
{
    void CalculateAndSetKpi(Employee employee);
    decimal? GetAverageKpi(IEnumerable<Employee> employees);
}
