using AutoMapper;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.DTOs.TaskAssignment;
using TaskManagementApplication.DTOs.TaskCategory;
using TaskManagementApplication.DTOs.TaskEntity;

namespace TaskManagementApplication.Services.AutoMapperProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region TaskCategory Profiles
            CreateMap<TaskCategory, TaskCategoryDTO>().ReverseMap(); 
            CreateMap<TaskCategory,CreateTaskCategoryDTO >().ReverseMap();
            CreateMap<TaskCategory,EditTaskCategoryDTO >().ReverseMap();
            #endregion

            CreateMap<TaskEntity, TaskEntityDTO>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskEntityDTO>().ReverseMap(); 


            CreateMap<TaskAssignment, CreateTaskAssignmentDTO>().ReverseMap(); 
            CreateMap<TaskAssignment, TaskAssignmentDTO>().ReverseMap(); 
        }
    }
}
