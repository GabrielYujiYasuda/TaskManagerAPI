using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class TaskManagerDBContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        //Constructor
        public TaskManagerDBContext(DbContextOptions<TaskManagerDBContext> options) 
            : base(options)
        {
        }
    }
}
