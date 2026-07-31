using Application.DTO;
using Application.Interfaces;
using Application.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
          
    public class UserServices(IUserRepository userRepository) : IUserServices
    {
         public async Task<BaseResponse<LoginResponseModel>> Login(LoginRequestModel model)
         {
             var user = await userRepository.GetUserAsync(model.Email);
             if (user == null)
             {
                return new BaseResponse<LoginResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Invalid Email"
                };
             }

             bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword);

             if (!isPasswordCorrect)
             {
                 return new BaseResponse<LoginResponseModel>
                 {
                      IsSuccessful = false,
                      Message = "Invalid Password"
                 };
             }

             return new BaseResponse<LoginResponseModel>
             {
                IsSuccessful = true,
                Message = "Login Successful",
                Data = new LoginResponseModel
                {
                    Id = user.Id,

                }
             };
         }
    }
}
    
          
