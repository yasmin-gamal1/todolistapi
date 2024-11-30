using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoList.DTOs;
using ToDoList.Repositories;
using ToDoList.Models;
using Task = ToDoList.Models.Task;
using AutoMapper;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskStatusController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpPut("{id}/complete")]
        [SwaggerOperation(
            Summary = "Mark task as completed",
            Description = "Update the status of a specific task to completed"
        )]
        [SwaggerResponse(200, "Task marked as completed successfully", typeof(TaskResponseDto))]
        [SwaggerResponse(404, "Task not found")]
        public async Task<ActionResult<TaskResponseDto>> MarkTaskAsCompleted(
            [SwaggerParameter("Unique identifier of the task")] int id)
        {
            var task = await _taskRepository.UpdateTaskStatusAsync(id, true);
            if (task == null) return NotFound();
            return Ok(_mapper.Map<TaskResponseDto>(task));
        }

        [HttpPut("{id}/incomplete")]
        [SwaggerOperation(
            Summary = "Mark task as incomplete",
            Description = "Update the status of a specific task to incomplete"
        )]
        [SwaggerResponse(200, "Task marked as incomplete successfully", typeof(TaskResponseDto))]
        [SwaggerResponse(404, "Task not found")]
        public async Task<ActionResult<TaskResponseDto>> MarkTaskAsIncomplete(
            [SwaggerParameter("Unique identifier of the task")] int id)
        {
            var task = await _taskRepository.UpdateTaskStatusAsync(id, false);
            if (task == null) return NotFound();
            return Ok(_mapper.Map<TaskResponseDto>(task));
        }

        [HttpPut("{id}/priority")]
        [SwaggerOperation(
            Summary = "Update task priority",
            Description = "Change the priority of a specific task"
        )]
        [SwaggerResponse(200, "Task priority updated successfully", typeof(TaskResponseDto))]
        [SwaggerResponse(404, "Task not found")]
        [SwaggerResponse(400, "Invalid priority value")]
        public async Task<ActionResult<TaskResponseDto>> UpdateTaskPriority(
            [SwaggerParameter("Unique identifier of the task")] int id,
            [FromQuery, SwaggerParameter("New priority level for the task")] TaskPriority priority)
        {
            var task = await _taskRepository.UpdateTaskPriorityAsync(id, priority);
            if (task == null) return NotFound();
            return Ok(_mapper.Map<TaskResponseDto>(task));
        }
    }
}