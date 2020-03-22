using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kanban.Model.Entities;
using Kanban.Model.Shared.Service;

namespace Kanban.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        {
            return _employeeService.GetAll();
        }
    }
}