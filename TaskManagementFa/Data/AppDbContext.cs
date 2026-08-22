using Microsoft.EntityFrameworkCore;
using TaskManagementFa.Model;

namespace TaskManagementFa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
