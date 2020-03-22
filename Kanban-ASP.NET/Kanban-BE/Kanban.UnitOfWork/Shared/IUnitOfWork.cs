using Kanban.Model.Entities;
using Kanban.Repository.Collections;
using Kanban.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.UnitOfWork.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }

        ITaskRepository TaskRepository { get; }

        ITaskListRepository TaskListRepository { get; }

        void Save();
    }
}
