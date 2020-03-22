using Kanban.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Service
{
    public interface ITaskListService
    {
        Task<IList<TaskListModel>> GetTaskLists();
    }
}
