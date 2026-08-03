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
        public class CustomerServices(ICustomerRepository customerRepository) : ICustomerService
        {
            public async Task<BaseResponse<CustomerResponseModel>> RegisterCustomer(CustomerRequestModel request)
            {
                var customerExist = await customerRepository.GetCustomerAsync(request.Email);

                if (customerExist != null)
                {
                    return new BaseResponse<CustomerResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Customer already exists."
                    };
                }

                var customer = new Customer
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address
                };

                await customerRepository.CreateCustomer(customer);

                return new BaseResponse<CustomerResponseModel>
                {
                    IsSuccessful = true,
                    Message = "Customer registered successfully.",
                    Data = new CustomerResponseModel
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                        Address = customer.Address
                    }
                };

            }   
            public async Task<BaseResponse<CustomerResponseModel>> DeleteCustomer(string email)
            {
                var customer = await customerRepository.GetCustomerAsync(email);

                if (customer == null)
                {
                    return new BaseResponse<CustomerResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Customer not found."
                    };
                }

                await customerRepository.DeleteCustomer(customer);

                return new BaseResponse<CustomerResponseModel>
                {
                    IsSuccessful = true,
                    Message = "Customer deleted successfully."
                };
            }

            public async Task<BaseResponse<ICollection<CustomerResponseModel>>> GetAllCustomers()
            {
                var customers = await customerRepository.GetAllCustomersAsync();

                var response = customers.Select(c => new CustomerResponseModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address
                }).ToList();

                return new BaseResponse<ICollection<CustomerResponseModel>>
                {
                    IsSuccessful = true,
                    Data = response
                };
            }

            public async Task<BaseResponse<CustomerResponseModel>> GetCustomerById(string email)
            {
                var customer = await customerRepository.GetCustomerAsync(email);

                if (customer == null)
                {
                    return new BaseResponse<CustomerResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Customer not found."
                    };
                }

                return new BaseResponse<CustomerResponseModel>
                {
                    IsSuccessful = true,
                    Data = new CustomerResponseModel
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                        Address = customer.Address
                    }
                };
            }

            public async Task<BaseResponse<CustomerResponseModel>> UpdateCustomer(string email, CustomerResponseModel request)
            {
                var customer = await customerRepository.GetCustomerAsync(email);

                if (customer == null)
                {
                    return new BaseResponse<CustomerResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Customer not found."
                    };
                }

                customer.FirstName = request.FirstName;
                customer.LastName = request.LastName;
                customer.Email = request.Email;
                customer.PhoneNumber = request.PhoneNumber;
                customer.Address = request.Address;

                await customerRepository.Update(customer);

                return new BaseResponse<CustomerResponseModel>
                {
                    IsSuccessful = true,
                    Message = "Customer updated successfully.",
                    Data = new CustomerResponseModel
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                        Address = customer.Address
                    }
                };
            }
        

        }
    
  }