//namespace CrudOpeartionDotNetCore.Data
//{
//    public class ApplicationDbContext
//    {
//    }
//}

using CrudOpeartionDotNetCore.Data;

using CrudOpeartionDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Cart.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Catego { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "HR" },
                new Department { DepartmentId = 2, Name = "OPERATION" },
                new Department { DepartmentId = 3, Name = "DEVELOPMENT" }
                );
        }


        public DbSet<CrudOpeartionDotNetCore.Models.DepartmentView> DepartmentView { get; set; } = default!;
    }

}
