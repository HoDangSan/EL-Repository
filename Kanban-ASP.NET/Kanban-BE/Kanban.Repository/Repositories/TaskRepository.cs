using Kanban.Model.Entities;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Collections;

namespace Kanban.Repository.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(KanbanDbContext context) : base(context)
        {

        }
    }
}
