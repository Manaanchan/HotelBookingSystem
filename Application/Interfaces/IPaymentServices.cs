using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPaymentService
    {
        Task<BaseResponse<PaymentResponseModel>> MakePayment(PaymentRequestModel request);
        Task<BaseResponse<PaymentResponseModel>> GetPayment(Guid id);
        Task<BaseResponse<ICollection<PaymentResponseModel>>> GetAllPayments();
        Task<BaseResponse<PaymentResponseModel>> DeletePayment(Guid id);
    }
}
