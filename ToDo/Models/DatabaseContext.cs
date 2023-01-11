using Microsoft.EntityFrameworkCore;

namespace ToDo.Models
{
    public class DatabaseContext :DbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<Plan> Plans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=ToDoList; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
