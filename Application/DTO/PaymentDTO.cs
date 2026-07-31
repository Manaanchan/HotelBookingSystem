using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PaymentDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = default!;
        public string PaymentStatus { get; set; } = default!;
        public string TransactionReference { get; set; } = default!;
        public string Currency { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Remarks { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
    public class PaymentRequestModel
    {
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = default!;
        public string PaymentStatus { get; set; } = default!;
        public string TransactionReference { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Remarks { get; set; } = default!;
    }

    public class PaymentResponseModel
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = default!;
        public string TransactionReference { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = default!;

    }
}
