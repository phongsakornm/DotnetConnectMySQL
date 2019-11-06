using DotnetConnectMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetConnectMySQL.Services
{
    public interface IDepartmentService
    {
        List<DepartmentModel> GetDepartmentListByDepId(string depID);
    }
}
