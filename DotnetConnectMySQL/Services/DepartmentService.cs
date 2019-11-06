using DotnetConnectMySQL.Contexts;
using DotnetConnectMySQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetConnectMySQL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentContext _departmentContext;
        public DepartmentService(IDepartmentContext departmentContext) {
            _departmentContext = departmentContext;
        }

        public List<DepartmentModel> GetDepartmentListByDepId(string depID)
        {
            List<DepartmentModel> departmentModelList = new List<DepartmentModel>();
            try
            {
                departmentModelList = _departmentContext.departmentModel
                    .Where(m => m.departmentID == depID)
                    .ToList();

                return departmentModelList;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return departmentModelList;
            }
        }
    }
}
