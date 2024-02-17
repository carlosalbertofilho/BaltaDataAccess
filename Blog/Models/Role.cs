
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Role]")]
    internal class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
