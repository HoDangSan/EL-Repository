using System.Collections.Generic;
using System.Threading.Tasks;
using Kanban.Model.Models;
using Kanban.Model.Shared.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private ITaskListService _taskListService;
        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        // GET: api/lists
        [HttpGet]
        public async Task<IList<TaskListModel>> Get()
        {
            return await _taskListService.GetTaskLists();
        }
    }
}
