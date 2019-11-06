using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetConnectMySQL.Models;
using DotnetConnectMySQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetConnectMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) {
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartmentListByDepId/{depID}")]
        public List<DepartmentModel> GetDepartmentListByDepId(string depID)
        {
            return _departmentService.GetDepartmentListByDepId(depID);
        }
    }
}