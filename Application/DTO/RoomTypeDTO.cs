using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class RoomTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal PricePerNight { get; set; }
        public string Description { get; set; } = default!;
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class RoomTypeRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }

    public class RoomTypeResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
