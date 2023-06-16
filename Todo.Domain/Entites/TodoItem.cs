using System;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.Domain.Common;
using Todo.Domain.Enums;

namespace Todo.Domain.Entites
{
    public class TodoItem : BaseDomainEntity
    {
        public string? Title { get; set; }
        public string? Note { get; set; }
        public PriorityLevel Priority { get; set; }
        public StatusLevel Status { get; set; }
        public DateTime? Reminder { get; set; }
        public Users? User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
