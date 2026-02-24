using KpiWebApp.Models;
using KpiWebApp.Models.ViewModels;
using KpiWebApp.Repositories;
using KpiWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace KpiWebApp.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _repository;
    private readonly IKpiService _kpiService;

    public EmployeesController(IEmployeeRepository repository, IKpiService kpiService)
    {
        _repository = repository;
        _kpiService = kpiService;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _repository.GetAllAsync();
        var viewModels = employees.Select(MapToViewModel).ToList();
        return View(viewModels);
    }

    public async Task<IActionResult> Details(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null) return NotFound();
        return View(MapToViewModel(employee));
    }

    public IActionResult Create()
    {
        return View(new EmployeeViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var employee = MapToEntity(model);
            _kpiService.CalculateAndSetKpi(employee);
            await _repository.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null) return NotFound();
        return View(MapToViewModel(employee));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EmployeeViewModel model)
    {
        if (id != model.Id) return NotFound();
        if (ModelState.IsValid)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return NotFound();
            employee.Name = model.Name;
            employee.Department = model.Department;
            employee.TargetSales = model.TargetSales;
            employee.ActualSales = model.ActualSales;
            employee.AttendanceDays = model.AttendanceDays;
            employee.TotalWorkingDays = model.TotalWorkingDays;
            _kpiService.CalculateAndSetKpi(employee);
            await _repository.UpdateAsync(employee);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null) return NotFound();
        return View(MapToViewModel(employee));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _repository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private static Employee MapToEntity(EmployeeViewModel model)
    {
        return new Employee
        {
            Id = model.Id,
            Name = model.Name,
            Department = model.Department,
            TargetSales = model.TargetSales,
            ActualSales = model.ActualSales,
            AttendanceDays = model.AttendanceDays,
            TotalWorkingDays = model.TotalWorkingDays
        };
    }

    private static EmployeeViewModel MapToViewModel(Employee entity)
    {
        return new EmployeeViewModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Department = entity.Department,
            TargetSales = entity.TargetSales,
            ActualSales = entity.ActualSales,
            AttendanceDays = entity.AttendanceDays,
            TotalWorkingDays = entity.TotalWorkingDays,
            SalesScore = entity.SalesScore,
            AttendanceScore = entity.AttendanceScore,
            FinalKpi = entity.FinalKpi
        };
    }
}
