using System.ComponentModel.DataAnnotations.Schema;

namespace AISDemoApp
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public Cart Cart { get; set; }
    }
}
