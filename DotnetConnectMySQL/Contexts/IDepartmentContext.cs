using DotnetConnectMySQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetConnectMySQL.Contexts
{
    public interface IDepartmentContext
    {
        DbSet<DepartmentModel> departmentModel { get; set; }
        int DepartmentSaveChanges();
    }
}
