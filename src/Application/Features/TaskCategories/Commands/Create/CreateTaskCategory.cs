﻿using AutoMapper;
using MediatR;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Exception;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskCategories.Commands.Create
{
    public class CreateTaskCategory : IRequest<ResponseModel>
    {
        public CreateTaskCategoryDTO CreateTaskCategoryDTO { get; set; }
    }

    public class CreateTaskCategoryCommandHandler : IRequestHandler<CreateTaskCategory, ResponseModel>
    {
        private readonly ITaskCategoryRepository _repo;
        private readonly IMapper _mapper;

        public CreateTaskCategoryCommandHandler(ITaskCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(CreateTaskCategory request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();
            var validator = new CreateTaskCategoryValidator().Validate(request.CreateTaskCategoryDTO);
            if (!validator.IsValid)
                throw new ValidationException(validator);


            var entity = _mapper.Map<TaskCategory>(request.CreateTaskCategoryDTO);
            var createdEntity = await _repo.Create(entity);
            response.Status = true;
            response.Message = "Created Succfully with Id : " + createdEntity.Id;


            return response;
        }
    }
}
