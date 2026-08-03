using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{ 
    public interface ICustomerService
    {
        Task<BaseResponse<CustomerResponseModel>> RegisterCustomer(CustomerRequestModel request);
        Task<BaseResponse<CustomerResponseModel>> GetCustomerById(string email);
        Task<BaseResponse<ICollection<CustomerResponseModel>>> GetAllCustomers();
        Task<BaseResponse<CustomerResponseModel>> DeleteCustomer(string email);
        Task<BaseResponse<CustomerResponseModel>> UpdateCustomer(string email,CustomerResponseModel request);
    }
    
}
