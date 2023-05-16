using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<TaskModel> TaskDB { get; set; }
}