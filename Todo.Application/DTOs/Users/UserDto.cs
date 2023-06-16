using System;
using Todo.Application.DTOs.Common;

namespace Todo.Application.DTOs.Users
{
    public class UserDto : BaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
