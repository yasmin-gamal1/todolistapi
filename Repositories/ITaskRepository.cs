using ToDoList.Models;
using ToDoList.DTOs;
using Task = ToDoList.Models.Task; // Use alias for your custom Task model
using System.Threading.Tasks; // Keep this for async methods
namespace ToDoList.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Task>> GetAllTasksAsync(bool? completed = null, DateTime? dueDate = null, TaskPriority? priority = null);
        Task<Task?> GetTaskByIdAsync(int id);
        Task<Task> CreateTaskAsync(Task task);
        Task<Task?> UpdateTaskAsync(int id, Task task);
        Task<bool> DeleteTaskAsync(int id);
        Task<Task?> UpdateTaskStatusAsync(int id, bool isCompleted);
        Task<Task?> UpdateTaskPriorityAsync(int id, TaskPriority priority);
    }
}
