using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskAssignments.Commands.Create
{
    public class CreateTaskAsignment : IRequest<ResponseModel>
    {
        public CreateTaskAssignmentDTO   CreateTaskAssignmentDTO { get;     set; }
    }

    public class CreateTaskAsignmentHandler : IRequestHandler<CreateTaskAsignment, ResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly ITaskAssignment _taskAssignment;
        public CreateTaskAsignmentHandler(IMapper mapper, ITaskAssignment taskAssignment)
        {
            _mapper = mapper;
            _taskAssignment = taskAssignment;
        }
        public async Task<ResponseModel> Handle(CreateTaskAsignment request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();
            var model =  _mapper.Map<TaskAssignment>(request.CreateTaskAssignmentDTO);
            var create=await _taskAssignment.Create(model);
            return response;
        }
    }
}
