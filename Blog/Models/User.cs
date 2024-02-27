using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    [Table("[User]")]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Bio { get; set; } = string.Empty;

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Image { get; set; } = string.Empty;

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Slug { get; set; } = string.Empty;

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
