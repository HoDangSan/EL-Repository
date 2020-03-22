using Kanban.Model.Models;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanban.Service.Implements
{
    public class TaskListService : BaseService, ITaskListService
    {
        public TaskListService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Task<IList<TaskListModel>> GetTaskLists()
        {
            return _unitOfWork.TaskListRepository.GetTaskLists();
        }
    }
}
