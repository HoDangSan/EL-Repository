using System;
using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public TaskModel Get(int id)
        {
            // Get Task follow id
            var task = _taskService.GetById(id);

            // Map Tast to TaskViewModel
            var model = _mapper.Map<TaskModel>(task);

            return model;
        }

        // PUT: api/tasks/5
        [HttpPut("{id:int}")]
        public void Put([FromBody] Task model)
        {
            _taskService.Update(model);
        }

        // POST: api/tasks
        [HttpPost]
        public void Post([FromBody] TaskModelToCreate model)
        {
            model.StartDate = DateTime.Now;

            var task = _mapper.Map<Task>(model);

            _taskService.Add(task);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
             var task = _taskService.GetById(id);
            if (task == null)
            {
                return Json("not Found");
            }
            else
            {
                _taskService.Delete(task.Id);
            }
            return Json("delelte success");
        }
    }
}
