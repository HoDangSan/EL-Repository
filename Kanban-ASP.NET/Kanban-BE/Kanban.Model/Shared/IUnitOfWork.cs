using Kanban.Model.Shared.Repository;
using System;

namespace Kanban.Model.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }

        ITaskRepository TaskRepository { get; }

        ITaskListRepository TaskListRepository { get; }

        void Save();
    }
}
