using System.ComponentModel.DataAnnotations;

namespace KpiWebApp.Models.ViewModels;

public class EmployeeViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(200)]
    [Display(Name = "Employee Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    [StringLength(100)]
    public string Department { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Target Sales must be greater than 0")]
    [Display(Name = "Target Sales")]
    public decimal TargetSales { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    [Display(Name = "Actual Sales")]
    public decimal ActualSales { get; set; }

    [Required]
    [Range(0, 365)]
    [Display(Name = "Attendance Days")]
    public int AttendanceDays { get; set; }

    [Required]
    [Range(1, 365)]
    [Display(Name = "Total Working Days")]
    public int TotalWorkingDays { get; set; }

    [Display(Name = "Sales Score")]
    public decimal? SalesScore { get; set; }

    [Display(Name = "Attendance Score")]
    public decimal? AttendanceScore { get; set; }

    [Display(Name = "Final KPI")]
    public decimal? FinalKpi { get; set; }
}
