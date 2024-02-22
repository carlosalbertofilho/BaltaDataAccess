
using Blog.Validation;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]
    public class User
    {
        public int Id { get; set; }
        [NotNullOrWhiteSpace]
        public required string Name { get; set; }
        [NotNullOrWhiteSpace]
        public required string Email { get; set; }
        [NotNullOrWhiteSpace]
        public required string PasswordHash { get; set; }
        [NotNullOrWhiteSpace]
        public required string Bio { get; set; }
        [NotNullOrWhiteSpace]
        public required string Image { get; set; }
        [NotNullOrWhiteSpace]
        public required string Slug { get; set; }
        public DateTime CreatedAt { get; set; }

        [Write(false)]
        public List<Role> Roles { get; set; } = [];

        public override string? ToString()
        {
            return $"{this.Id} -> {this.Name} " +
                   $"\n\t Email :    \t{this.Email} " +
                   $"\n\t Bio:       \t{this.Bio} " +
                   $"\n\t URL Image: \t{this.Image} " +
                   $"\n\t Slug:      \t{this.Slug}";
        }
    }
}
