using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<BaseResponse<RoleResponseModel>> CreateRole(RoleRequestModel request);
        Task<BaseResponse<RoleResponseModel>> GetRole(Guid id);
        Task<BaseResponse<ICollection<RoleResponseModel>>> GetAllRoles();
        Task<BaseResponse<RoleResponseModel>> DeleteRole(Guid id);
        Task<BaseResponse<RoleResponseModel>> Update(Guid id,RoleRequestModel request);
    }
}
