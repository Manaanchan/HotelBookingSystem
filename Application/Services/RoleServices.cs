using Application.DTO;
using Application.Interfaces;
using Application.Repository;
using Application.Services;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class RoleServices(IRoleRepository roleRepository) : IRoleService
    {
        public async Task<BaseResponse<RoleResponseModel>> CreateRole(RoleRequestModel request)
        {
            var exist = await roleRepository.AddRole(request.Name);

            if (exist != null)
            {
                return new BaseResponse<RoleResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Role already exists."
                };
            }

            var role = new Role
            {
                Name = request.Name,
                Description = request.Description
            };

            await roleRepository.AddRole(role);
            return new BaseResponse<RoleResponseModel>
            {
                IsSuccessful = true,
                Message = "Role created successfully.",
                Data = new RoleResponseModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };
        }

        public async Task<BaseResponse<RoleResponseModel>> DeleteRole(Guid id)
        {
            var role = await roleRepository.GetRoleById(id);

            if (role == null)
            {
                return new BaseResponse<RoleResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Role not found."
                };
            }
            roleRepository.Delete(role);

            return new BaseResponse<RoleResponseModel>
            {
                IsSuccessful = true,
                Message = "Role deleted successfully.",
                Data = new RoleResponseModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };
        
        }

        public async Task<BaseResponse<ICollection<RoleResponseModel>>> GetAllRoles()
        {
            var roles = await roleRepository.GetAllRole();

            var response = roles.Select(r => new RoleResponseModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();

            return new BaseResponse<ICollection<RoleResponseModel>>
            {
                IsSuccessful = true,
                Data = response
            };
        }

        public async Task<BaseResponse<RoleResponseModel>> GetRole(Guid id)
        {

            var role = await roleRepository.GetRoleById(id);

            if (role == null)
            {
                return new BaseResponse<RoleResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Role not found."
                };
            }

            return new BaseResponse<RoleResponseModel>
            {
                IsSuccessful = true,
                Data = new RoleResponseModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };
        }

        public async Task<BaseResponse<RoleResponseModel>> Update(Guid id,RoleRequestModel request)
        {
            var role = await roleRepository.GetRoleById(id);

            if (role == null)
            {
                return new BaseResponse<RoleResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Role not found."
                };
            }

            role.Name = request.Name;
            role.Description = request.Description;

            roleRepository.Update(role);
            return new BaseResponse<RoleResponseModel>
            {
                IsSuccessful = true,
                Message = "Role updated successfully.",
                Data = new RoleResponseModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };
        }

        
    }
}

