using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IBookingServices
    {
        Task<BaseResponse<BookingResponseModel>> CreateBooking(BookingRequestModel request);
        Task<BaseResponse<BookingResponseModel>> GetBooking(Guid id);
        Task<BaseResponse<ICollection<BookingResponseModel>>> GetAllBookings();
        Task<BaseResponse<BookingResponseModel>> DeleteBooking(Guid id);
        
    }
}
