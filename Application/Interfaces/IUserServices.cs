using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<BaseResponse<LoginResponseModel>> Login(LoginRequestModel model);

    }
}
