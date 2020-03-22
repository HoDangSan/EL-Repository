using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Collections;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Repository.Repositories
{
    public class TaskListRepository : GenericRepository<TaskList>, ITaskListRepository
    {
        public TaskListRepository(KanbanDbContext context) : base(context) { }


        public async Task<IList<TaskListModel>> GetTaskLists()
        {
            return await _context.TaskList.Select(x => new TaskListModel
            {
                Id = x.Id,
                Name = x.Name,
                Tasks = x.Task.OrderBy(_ => _.IndexTask).Select(c => new TaskModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    OwnerId = c.OwnerId,
                    StartDate = c.StartDate,
                    DueDate = c.DueDate,
                    TaskStatuts = c.TaskStatuts,
                    Priority = c.Priority,
                    Completion = c.Completion,
                    AssignedEmployeeId = c.AssignedEmployeeId,
                    IndexTask = c.IndexTask,
                    ListId = c.ListId,
                    AssignedEmployee = new EmployeeModel
                    {
                        Id = c.AssignedEmployee.Id,
                        Name = c.AssignedEmployee.Name
                    },
                    Owner = new EmployeeModel
                    {
                        Id = c.AssignedEmployee.Id,
                        Name = c.AssignedEmployee.Name
                    },
                }).ToList()
            }).ToListAsync();
        }
    }
}
