using Kanban.Model.Entities;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;

namespace Kanban.Service.Implements
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Add(Task task)
        {
            _unitOfWork.TaskRepository.Add(task);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.TaskRepository.Delete(id);
            _unitOfWork.Save();
        }

        public Task GetById(int? id) => _unitOfWork.TaskRepository.Get(id);

        public void Update(Task input)
        {
            //1. Get task by id input.Id
            var task = GetById(input.Id);
            
            //2. Update task with info from input
            task.IndexTask = input.IndexTask;
            task.ListId = input.ListId;
            task.StartDate = input.StartDate;
            task.Name = input.Name;
            task.OwnerId = input.OwnerId;
            task.AssignedEmployeeId = input.AssignedEmployeeId;
            task.DueDate = input.DueDate;
            task.Completion = input.Completion;
            task.Priority = input.Priority;

            _unitOfWork.Save();
        }
    }
}
