using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IPaymentRepository
    {
        Task Add(Payment payment);
        Task<Payment> GetPayment(Guid id);
        Task<ICollection<Payment>> GetAllPayment();
        void Delete(Guid id);
    }
}
