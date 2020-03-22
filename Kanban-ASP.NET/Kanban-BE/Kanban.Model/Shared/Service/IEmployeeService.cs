using Kanban.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Model.Shared.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
    }
}
