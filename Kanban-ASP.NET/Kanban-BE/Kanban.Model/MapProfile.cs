using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;

namespace Kanban.Model
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Task, TaskModel>().ReverseMap(); ;

            CreateMap<TaskModelToCreate, Task>().ReverseMap(); ;
        }
    }
}
