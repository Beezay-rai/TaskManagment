using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagementApplication.Common;
using TaskManagementApplication.DTOs.TaskAssignment;
using TaskManagementApplication.Interfaces;

namespace TaskManagementApplication.Features.TaskAssignments.Commands.Update
{

    #region Update

    public class EditTaskAssignment : IRequest<(int HttpStatusCode, object data)>
    {
        public EditTaskAssignmentDTO EditTaskAssignmentDTO { get; set; }
    }

    public class EditTaskAssignmentCommandHandler : IRequestHandler<EditTaskAssignment, (int HttpStatusCode, object data)>
    {
        private readonly IGenericRepository<TaskAssignment> _repo;
        private readonly IMapper _mapper;

        public EditTaskAssignmentCommandHandler(IGenericRepository<TaskAssignment> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<(int HttpStatusCode, object data)> Handle(EditTaskAssignment request, CancellationToken cancellationToken)
        {
            var response = new ResponseModel();


            try
            {
                var entity = _mapper.Map<TaskAssignment>(request.EditTaskAssignmentDTO);
                await _repo.UpdateAsync(entity);
                response.Status = true;
                response.Message = "Updated Sucessfully !";
                return (200, response);

            }
            catch (System.Exception e)
            {
                var errorModel = new ErrorResponseModel
                {
                    Message = " Internal Server Error !",
                    ErrorDescription = new List<string> { e.InnerException?.Message }
                };
                return (500, errorModel);
            }



        }
    }
    #endregion
}
