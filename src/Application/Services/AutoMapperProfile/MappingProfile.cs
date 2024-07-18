using AutoMapper;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.DTOs;

namespace TaskManagementApplication.Services.AutoMapperProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskCategory, TaskCategoryDTO>().ReverseMap(); 
            CreateMap<TaskCategory,CreateTaskCategoryDTO >().ReverseMap(); 
            CreateMap<TaskEntity, TaskEntityDTO>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskEntityDTO>().ReverseMap(); 
            CreateMap<TaskAssignment, CreateTaskAssignmentDTO>().ReverseMap(); 
        }
    }
}
