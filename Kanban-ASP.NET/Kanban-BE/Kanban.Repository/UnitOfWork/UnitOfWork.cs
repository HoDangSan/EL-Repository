using Kanban.Model.Entities;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Repositories;
using System;

namespace Kanban.UnitOfWork.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private KanbanDbContext _context;

        public UnitOfWork(KanbanDbContext context)
        {
            _context = context;
            InitReponsitory();
        }

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public ITaskRepository TaskRepository { get; private set; }

        public ITaskListRepository TaskListRepository { get; private set; }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            // Execute if resources have not already been disposed
            if (!_disposed)
            {
                // If the call is from Dispose, free managed resources
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// To release unmanaged resources before an object is garbage-collected.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // Requests that the common language runtime not call the finalizer for the specified object.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Init Objects Repository 
        /// </summary>
        private void InitReponsitory() {
            EmployeeRepository = new EmployeeRepository(_context);
            TaskRepository = new TaskRepository(_context);
            TaskListRepository = new TaskListRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
