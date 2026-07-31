using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Implementation
{
    public class PaymentRepository(HotelDbContext context) : IPaymentRepository
    {
        public async Task Add(Payment payment)
        {
            await context.Payments.AddAsync(payment);
        }

        public async Task<Payment> GetPayment(Guid id)
        {
            return await context.Payments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Payment>> GetAllPayment()
        {
            return await context.Payments.ToListAsync();
        }


        public void Delete(Guid id)
        {
            var payment = context.Payments.FirstOrDefault(r => r.Id == id);
            if (payment != null)
            {
                context.Payments.Remove(payment);
                context.SaveChanges();
            }
        }
    
    }
}
