using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoList.DTOs;
using ToDoList.Models;
using ToDoList.Repositories;
using Task = ToDoList.Models.Task; 

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all tasks",
            Description = "Retrieve a list of tasks with optional filtering"
        )]
        [SwaggerResponse(200, "Successfully retrieved tasks", typeof(List<TaskResponseDto>))]
        public async Task<IActionResult> GetTasks(
            [FromQuery, SwaggerParameter("Filter tasks by completion status")] bool? completed,
            [FromQuery, SwaggerParameter("Filter tasks by due date")] DateTime? dueDate,
            [FromQuery, SwaggerParameter("Filter tasks by priority")] TaskPriority? priority)
        {
            var tasks = await _taskRepository.GetAllTasksAsync(completed, dueDate, priority);
            List<TaskResponseDto> tasksDto = _mapper.Map<List<TaskResponseDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get task by ID",
            Description = "Retrieve a specific task using its unique identifier"
        )]
        [SwaggerResponse(200, "Task found", typeof(TaskResponseDto))]
        [SwaggerResponse(404, "Task not found")]
        public async Task<IActionResult> GetTask(
            [SwaggerParameter("Unique identifier of the task")] int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null) return NotFound();

            return Ok(_mapper.Map<TaskResponseDto>(task));
        }

        [HttpPost]
        //[Authorize(Roles = "admin")] // Uncomment and adjust role if needed
        [SwaggerOperation(
            Summary = "Create a new task",
            Description = "Add a new task to the system"
        )]
        [SwaggerResponse(201, "Task created successfully", typeof(TaskResponseDto))]
        [SwaggerResponse(400, "Invalid task data")]
        public async Task<IActionResult> CreateTask(
            [FromBody, SwaggerRequestBody("Task creation details")] CreateTaskDto createTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = _mapper.Map<Task>(createTaskDto);
            var createdTask = await _taskRepository.CreateTaskAsync(task);

            return CreatedAtAction(
                nameof(GetTask),
                new { id = createdTask.Id },
                _mapper.Map<TaskResponseDto>(createdTask)
            );
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")] // Uncomment and adjust role if needed
        [SwaggerOperation(
            Summary = "Update an existing task",
            Description = "Modify details of an existing task"
        )]
        [SwaggerResponse(200, "Task updated successfully", typeof(TaskResponseDto))]
        [SwaggerResponse(400, "Invalid task data")]
        [SwaggerResponse(404, "Task not found")]
        public async Task<IActionResult> UpdateTask(
            [SwaggerParameter("Unique identifier of the task")] int id,
            [FromBody, SwaggerRequestBody("Task update details")] UpdateTaskDto updateTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = _mapper.Map<Task>(updateTaskDto);
            task.Id = id;

            var updatedTask = await _taskRepository.UpdateTaskAsync(id, task);
            if (updatedTask == null) return NotFound();

            return Ok(_mapper.Map<TaskResponseDto>(updatedTask));
        }

        [HttpDelete("{id}")]
        
        [SwaggerOperation(
            Summary = "Delete a task",
            Description = "Remove a task from the system"
        )]
        [SwaggerResponse(204, "Task deleted successfully")]
        [SwaggerResponse(404, "Task not found")]
        public async Task<IActionResult> DeleteTask(
            [SwaggerParameter("Unique identifier of the task")] int id)
        {
            var result = await _taskRepository.DeleteTaskAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}