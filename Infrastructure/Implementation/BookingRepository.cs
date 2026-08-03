using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Implementation
{
    public class BookingRepository(HotelDbContext context) : IBookingRepository
    {
        public async Task CreateBookingAsync(Booking booking)
        {
            await  context.Bookings.AddAsync(booking);
        }

        public void DeleteBooking(Guid id)
        {
            var booking = context.Bookings.FirstOrDefault(r => r.Id == id);
            if (booking != null)
            {
                context.Bookings.Remove(booking);
                context.SaveChanges();
            }
        }

        public async Task<ICollection<Booking>> GetAllBookings()
        {
            return await context.Bookings.ToListAsync(); 
        }

        public async Task<Booking> GetBookingByIdAsync(Guid id)
        {
            return await context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateBooking(Booking booking)
        {

            context.Bookings.Update(booking);
            context.SaveChanges();
        }
    }
}


