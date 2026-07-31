using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{ 
    public interface ICustomerService
    {
        Task<BaseResponse<CustomerResponseModel>> RegisterCustomer(CustomerRequestModel request);
        Task<BaseResponse<CustomerResponseModel>> GetCustomerById(Guid id);
        Task<BaseResponse<ICollection<CustomerResponseModel>>> GetAllCustomers();
        Task<BaseResponse<CustomerResponseModel>> DeleteCustomer(Guid id);
        Task<BaseResponse<CustomerResponseModel>> UpdateCustomer(CustomerResponseModel request);
    }
    
}
