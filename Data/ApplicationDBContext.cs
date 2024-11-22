using lunarcake.Models;
using Microsoft.EntityFrameworkCore;

namespace lunarcake.Data;

public class ApplicationDBContext : DbContext {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; } = null!;
}
