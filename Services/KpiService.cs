using KpiWebApp.Models;

namespace KpiWebApp.Services;

public class KpiService : IKpiService
{
    public void CalculateAndSetKpi(Employee employee)
    {
        if (employee.TargetSales > 0)
        {
            employee.SalesScore = Math.Round((employee.ActualSales / employee.TargetSales) * 100, 2);
        }
        else
        {
            employee.SalesScore = 0;
        }

        if (employee.TotalWorkingDays > 0)
        {
            employee.AttendanceScore = Math.Round((decimal)employee.AttendanceDays / employee.TotalWorkingDays * 100, 2);
        }
        else
        {
            employee.AttendanceScore = 0;
        }

        employee.FinalKpi = Math.Round(
            employee.SalesScore * 0.7m + employee.AttendanceScore * 0.3m,
            2);
    }

    public decimal? GetAverageKpi(IEnumerable<Employee> employees)
    {
        var list = employees.ToList();
        if (list.Count == 0) return null;
        return Math.Round(list.Average(e => e.FinalKpi), 2);
    }
}
