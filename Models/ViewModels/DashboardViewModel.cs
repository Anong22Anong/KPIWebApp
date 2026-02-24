namespace KpiWebApp.Models.ViewModels;

public class DashboardViewModel
{
    public decimal? AverageKpi { get; set; }
    public IEnumerable<EmployeeKpiSummary> TopEmployees { get; set; } = new List<EmployeeKpiSummary>();
    public List<string> EmployeeNames { get; set; } = new();
    public List<decimal> KpiValues { get; set; } = new();
}

public class EmployeeKpiSummary
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public decimal? FinalKpi { get; set; }
}
