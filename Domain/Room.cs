using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Room
    {       
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RoomTypeId { get; set; }
        public string RoomNumber { get; set; } = default!;
        public int Price { get; set; }
        public string Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } 
    }
}
