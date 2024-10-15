using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskAssignments.Commands.Delete
{
    #region Delete
    public class DeleteTaskAssignment : IRequest<ResponseModel>
    {
        public int TaskAssignmentId { get; set; }
    }

    public class DeleteTaskAssignmentCommandHandler : IRequestHandler<DeleteTaskAssignment, ResponseModel>
    {
        private readonly ITaskAssignmentRepository _repo;
        private readonly IMapper _mapper;

        public DeleteTaskAssignmentCommandHandler(ITaskAssignmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(DeleteTaskAssignment request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();
            //var validator = new DeleteTaskAssignmentValidator().Validate(request.DeleteTaskAssignmentDTO);
            //if (!validator.IsValid)
            //    throw new ValidationException(validator);

            try
            {
                var entity = _mapper.Map<TaskAssignment>(request.TaskAssignmentId);
                await _repo.Delete(entity.Id);
                response.Status = true;
                response.Message = "Deleted Succfully with Id : " + entity.Id;
            }
            catch
            {
                response.Status = false;
                response.Message = "Failed to Delete Task Category ! ";
            }



            return response;
        }
    }

    #endregion

}
