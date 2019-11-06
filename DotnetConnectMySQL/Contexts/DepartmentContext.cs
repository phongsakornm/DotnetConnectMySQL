using DotnetConnectMySQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetConnectMySQL.Contexts
{
    public class DepartmentContext : DbContext, IDepartmentContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<DepartmentModel> departmentModel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var BrokerLogBuilder = builder.Entity<DepartmentModel>();
            BrokerLogBuilder.ToTable("ms09_department");
            BrokerLogBuilder.HasKey(x => new { x.departmentID });
        }

        public int DepartmentSaveChanges()
        {
            return this.SaveChanges();
        }
    }
}
