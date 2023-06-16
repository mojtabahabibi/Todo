using AutoMapper;
using Todo.Application.DTOs.TodoItems;
using Todo.Application.DTOs.Users;
using Todo.Domain.Entites;

namespace Todo.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Users,CreateUserDto>().ReverseMap(); 
            CreateMap<Users,UpdateUserDto>().ReverseMap();

            CreateMap<TodoItem,TodoItemDto>().ReverseMap();
            CreateMap<TodoItem,TodoItemShowDto>().ReverseMap();
            CreateMap<TodoItem,CreateTodoItemDto>().ReverseMap();
            CreateMap<TodoItem,UpdateTodoItemDto>().ReverseMap();
        }
    }
}
