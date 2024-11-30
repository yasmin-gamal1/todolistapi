using System.ComponentModel.DataAnnotations;
using ToDoList.Models;

namespace ToDoList.DTOs
{
    public class UpdateTaskDto
    {
        [MaxLength(200)]
        public string? Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskPriority? Priority { get; set; }
    }
}
