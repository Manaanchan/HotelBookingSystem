namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string HashPassword { get; set; } = default!;
        public string Salt { get; set; } = default!;
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
