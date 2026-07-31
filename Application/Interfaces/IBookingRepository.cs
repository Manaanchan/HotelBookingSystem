using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IBookingRepository
    {
        Task CreateBookingAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(Guid id);
        Task<ICollection<Booking>> GetAllBookings();
        void UpdateBooking(Booking booking);
        void DeleteBooking(Guid id);

    }
}

