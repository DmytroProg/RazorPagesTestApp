using Microsoft.EntityFrameworkCore;
using RazorPagesTestApp.Models;

namespace RazorPagesTestApp.Data;

public class RazorPagesTestAppContext : DbContext
{
    public RazorPagesTestAppContext(DbContextOptions<RazorPagesTestAppContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Student> Student { get; set; } = default!;
}