using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal TotalAmount { get; set; }
        public string BookingStatus { get; set; } = default!;
        public string PaymentMethod { get; set; } = default!;
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class BookingRequestModel
    {
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string PaymentMethod { get; set; } = default!;
    }
    public class BookingResponseModel
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string BookingStatus { get; set; } 
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal TotalAmount { get; set; }



    }
}
