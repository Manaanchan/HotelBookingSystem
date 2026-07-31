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
    public class PaymentServices(IPaymentRepository paymentRepository, IBookingRepository bookingRepository) : IPaymentService
    {

            public async Task<BaseResponse<PaymentResponseModel>> MakePayment(PaymentRequestModel request)
            {
                // Check if the booking exists
                var booking = await bookingRepository.GetBookingByIdAsync(request.BookingId);

                if (booking == null)
                {
                    return new BaseResponse<PaymentResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Booking not found."
                    };
                }

                var payment = new Payment
                {
                    BookingId = request.BookingId,
                    Amount = request.Amount,
                    PaymentMethod = request.PaymentMethod,
                    PaymentDate = DateTime.UtcNow,
                    TransactionReference = Guid.NewGuid().ToString(),
                    Status = "Paid"
                };

                await paymentRepository.Add(payment);

                return new BaseResponse<PaymentResponseModel>
                {
                    IsSuccessful = true,
                    Message = "Payment successful.",
                    Data = new PaymentResponseModel
                    {
                        Id = payment.Id,
                        BookingId = payment.BookingId,
                        Amount = payment.Amount,
                        PaymentMethod = payment.PaymentMethod,
                        PaymentDate = payment.PaymentDate,
                        TransactionReference = payment.TransactionReference,
                        Status = payment.Status
                    }
                };
            }

            public async Task<BaseResponse<PaymentResponseModel>> DeletePayment(Guid id)
            {
                var payment = await paymentRepository.GetPayment(id);

                if (payment == null)
                {
                    return new BaseResponse<PaymentResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Payment not found."
                    };
                }

                await paymentRepository.Delete(payment);

                return new BaseResponse<PaymentResponseModel>
                {
                    IsSuccessful = true,
                    Message = "Payment deleted successfully."
                };
            }

            public async Task<BaseResponse<ICollection<PaymentResponseModel>>> GetAllPayments()
            {
                var payments = await paymentRepository.GetAllPayment();

                var response = payments.Select(x => new PaymentResponseModel
                {
                    Id = x.Id,
                    BookingId = x.BookingId,
                    Amount = x.Amount,
                    PaymentMethod = x.PaymentMethod,
                    PaymentDate = x.PaymentDate,
                    TransactionReference = x.TransactionReference,
                    Status = x.Status
                }).ToList();

                return new BaseResponse<ICollection<PaymentResponseModel>>
                {
                    IsSuccessful = true,
                    Data = response
                };
            }

            public async Task<BaseResponse<PaymentResponseModel>> GetPayment(Guid id)
            {
                var payment = await paymentRepository.GetPayment(id);

                if (payment == null)
                {
                    return new BaseResponse<PaymentResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Payment not found."
                    };
                }

                return new BaseResponse<PaymentResponseModel>
                {
                    IsSuccessful = true,
                    Data = new PaymentResponseModel
                    {
                        Id = payment.Id,
                        BookingId = payment.BookingId,
                        Amount = payment.Amount,
                        PaymentMethod = payment.PaymentMethod,
                        PaymentDate = payment.PaymentDate,
                        TransactionReference = payment.TransactionReference,
                        Status = payment.Status
                    }
                };
            }
        }