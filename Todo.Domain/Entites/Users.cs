using System;
using System.Collections.Generic;
using Todo.Domain.Common;

namespace Todo.Domain.Entites
{
    public class Users : BaseDomainEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public ICollection<TodoItem>? Todoes { get; set; }
    }
}
