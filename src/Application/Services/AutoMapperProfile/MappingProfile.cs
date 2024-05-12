using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.DTOs;

namespace TaskManagementApplication.Services.AutoMapperProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskCategory, TaskCategoryDTO>().ReverseMap(); 
            CreateMap<TaskEntity, TaskEntityDTO>().ReverseMap(); 
            CreateMap<TaskEntity, CreateTaskEntityDTO>().ReverseMap(); 
        }
    }
}
