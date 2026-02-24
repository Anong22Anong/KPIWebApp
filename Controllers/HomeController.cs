using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KpiWebApp.Models;
using KpiWebApp.Models.ViewModels;
using KPIWebApp.Models;
using KpiWebApp.Repositories;
using KpiWebApp.Services;

namespace KPIWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IKpiService _kpiService;

    public HomeController(
        ILogger<HomeController> logger,
        IEmployeeRepository employeeRepository,
        IKpiService kpiService)
    {
        _logger = logger;
        _employeeRepository = employeeRepository;
        _kpiService = kpiService;
    }

    public async Task<IActionResult> Index()
    {
        var employees = (await _employeeRepository.GetAllAsync()).ToList();
        var topEmployees = (await _employeeRepository.GetTopByKpiAsync(5)).ToList();

        var viewModel = new DashboardViewModel
        {
            AverageKpi = _kpiService.GetAverageKpi(employees),
            TopEmployees = topEmployees.Select(e => new EmployeeKpiSummary
            {
                Id = e.Id,
                Name = e.Name,
                Department = e.Department,
                FinalKpi = e.FinalKpi
            }).ToList(),
            EmployeeNames = employees.Select(e => e.Name).ToList(),
            KpiValues = employees.Select(e => e.FinalKpi).ToList()
        };

        return View(viewModel);
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
