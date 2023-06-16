using System;
using Todo.Application.DTOs.Common;
using Todo.Domain.Enums;

namespace Todo.Application.DTOs.TodoItems
{
    public class TodoItemDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Note { get; set; }
        public PriorityLevel Priority { get; set; }
        public StatusLevel Status { get; set; }
        public DateTime? Reminder { get; set; }
        public int UserId { get; set; }
    }
}
