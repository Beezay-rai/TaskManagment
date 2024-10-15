﻿using AutoMapper;

            try
                var response = new ResponseModel();
                var validator = new DepartmentValidator<CreateDepartmentDTO>().Validate(request.CreateDepartmentDTO);
                if (!validator.IsValid)
                {
                    var ErrorModel = new ErrorResponseModel()
                    {
                        Status = false,
                        Message = "Validation Failed !",
                        ErrorDescription = validator.Errors.Select(x => x.ErrorMessage).ToList()

                    };
                    return (400, ErrorModel);
                }
                return (200, response);
                {
                    Status = false,
                    Message = e.InnerException.Message,

                };
                return (500, error);



        }