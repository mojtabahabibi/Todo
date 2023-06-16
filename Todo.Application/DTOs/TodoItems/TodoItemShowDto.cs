using Todo.Domain.Enums;

namespace Todo.Application.DTOs.TodoItems
{
    public class TodoItemShowDto : TodoItemDto
    {
        public string StatusShow
        {
            get
            {
                return Status == StatusLevel.Undone ? "Undone" : Status == StatusLevel.Doing ? "Doing" : "Done";
            }
        }
        public string PriorityShow
        {
            get
            {
                return Priority == PriorityLevel.None ? "None" : Priority == PriorityLevel.Low ? "Low" : Priority == PriorityLevel.Medium ? "Medium" : "High";
            }
        }
    }
}
