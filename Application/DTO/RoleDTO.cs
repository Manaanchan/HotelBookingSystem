using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class RoleRequestModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }

    public class RoleResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
