using Microsoft.EntityFrameworkCore;
using KpiWebApp.Models;

namespace KpiWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Employee>(e =>
        {
            e.Property(p => p.SalesScore).HasPrecision(18, 2);
            e.Property(p => p.AttendanceScore).HasPrecision(18, 2);
            e.Property(p => p.FinalKpi).HasPrecision(18, 2);
            e.Property(p => p.TargetSales).HasPrecision(18, 2);
            e.Property(p => p.ActualSales).HasPrecision(18, 2);
        });
    }
}
