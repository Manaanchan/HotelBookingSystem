using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RoomType
    {       
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public decimal PricePerNight { get; set; }
        public string Description { get; set; } = default!;
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
