using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpiWebApp.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Employee Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(80)]
    public string Department { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Target sales must be greater than 0")]
    [Display(Name = "Target Sales")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TargetSales { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    [Display(Name = "Actual Sales")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal ActualSales { get; set; }

    [Required]
    [Range(0, 365)]
    [Display(Name = "Attendance Days")]
    public int AttendanceDays { get; set; }

    [Required]
    [Range(1, 365)]
    [Display(Name = "Total Working Days")]
    public int TotalWorkingDays { get; set; }

    /// <summary>
    /// Calculated: (ActualSales / TargetSales) * 100
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal SalesScore { get; set; }

    /// <summary>
    /// Calculated: (AttendanceDays / TotalWorkingDays) * 100
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal AttendanceScore { get; set; }

    /// <summary>
    /// Calculated: (SalesScore * 0.7) + (AttendanceScore * 0.3)
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Final KPI")]
    public decimal FinalKpi { get; set; }
}
