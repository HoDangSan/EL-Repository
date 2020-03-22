using Kanban.Model.Entities;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;
using System.Collections.Generic;

namespace Kanban.Service.Implements
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork){}

        public IEnumerable<Employee> GetAll()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }
    }
}
