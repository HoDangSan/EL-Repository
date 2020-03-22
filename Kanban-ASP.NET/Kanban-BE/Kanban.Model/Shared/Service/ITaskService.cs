using Kanban.Model.Entities;

namespace Kanban.Model.Shared.Service
{
    public interface ITaskService
    {
        Task GetById(int? id);

        void Add(Task task);

        void Delete(int id);

        void Update(Task task);
    }
}
