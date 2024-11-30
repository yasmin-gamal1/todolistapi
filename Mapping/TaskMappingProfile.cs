using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using ToDoList.DTOs;
using Task = ToDoList.Models.Task;

namespace ToDoList.Mapping
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Profile is a valid AutoMapper class")]
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<CreateTaskDto, Task>();
            CreateMap<UpdateTaskDto, Task>();
            CreateMap<Task, TaskResponseDto>();
        }
    }
}
