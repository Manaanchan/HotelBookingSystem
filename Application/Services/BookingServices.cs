using Application.DTO;
using Application.Interfaces;
using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class BookingServices(IBookingRepository bookingRepository, ICustomerRepository customerRepository, IRoomRepository roomRepository) : IBookingServices
    {

        public async Task<BaseResponse<BookingResponseModel>> CreateBooking(BookingRequestModel request)
        {
            // Check if customer exists
            var customer = await customerRepository.GetCustomerAsync(request.CustomerId);

            if (customer == null)
            {
                return new BaseResponse<BookingResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Customer not found."
                };
            }

            // Check if room exists
            var room = await roomRepository.GetRoomByIdAsync(request.RoomId);

            if (room == null)
            {
                return new BaseResponse<BookingResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Room not found."
                };
            }

            var booking = new Booking
            {
                CustomerId = request.CustomerId,
                RoomId = request.RoomId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                NumberOfGuests = request.NumberOfGuests,
                BookingDate = DateTime.UtcNow,
                BookingStatus = "Pending"
            };

            await bookingRepository.CreateBookingAsync(booking);

            return new BaseResponse<BookingResponseModel>
            {
                IsSuccessful = true,
                Message = "Booking created successfully.",
                Data = new BookingResponseModel
                {
                    Id = booking.Id,
                    CustomerId = booking.CustomerId,
                    RoomNumber = booking.RoomNumber,
                    RoomType = booking.RoomType,
                    TotalAmount = booking.TotalAmount,
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    NumberOfGuests = booking.NumberOfGuests,
                    BookingStatus = booking.BookingStatus
                }
            };
        }

        public async Task<BaseResponse<BookingResponseModel>> DeleteBooking(Guid id)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return new BaseResponse<BookingResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Booking not found."
                };
            }
            await bookingRepository.DeleteBooking(booking);


            return new BaseResponse<BookingResponseModel>
            {
                IsSuccessful = true,
                Message = "Booking deleted successfully."
            };
        }

        public async Task<BaseResponse<ICollection<BookingResponseModel>>> GetAllBookings()
        {
            var bookings = await bookingRepository.GetAllBookings();

            var response = bookings.Select(x => new BookingResponseModel
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                RoomNumber = x.RoomNumber,
                RoomType = x.RoomType,
                TotalAmount = x.TotalAmount,
                CheckInDate = x.CheckInDate,
                CheckOutDate = x.CheckOutDate,
                NumberOfGuests = x.NumberOfGuests,
                BookingStatus = x.BookingStatus
            }).ToList();

            return new BaseResponse<ICollection<BookingResponseModel>>
            {
                IsSuccessful = true,
                Data = response
            };
        }

        public async Task<BaseResponse<BookingResponseModel>> GetBooking(Guid id)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return new BaseResponse<BookingResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Booking not found."
                };
            }

            return new BaseResponse<BookingResponseModel>
            {
                IsSuccessful = true,
                Data = new BookingResponseModel
                {
                    Id = booking.Id,
                    CustomerId = booking.CustomerId,
                    RoomNumber = booking.RoomNumber,
                    RoomType = booking.RoomType,
                    TotalAmount = booking.TotalAmount,
                    CheckInDate = booking.CheckInDate,
                    CheckOutDate = booking.CheckOutDate,
                    NumberOfGuests = booking.NumberOfGuests,
                    BookingStatus = booking.BookingStatus
                }
            };
        }
    }
}