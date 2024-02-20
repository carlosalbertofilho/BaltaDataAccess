
using Dapper.Contrib.Extensions;
using System.Data;

namespace Blog.Models
{
    [Table("[Role]")]
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id} | Nome: {this.Name} | Slug: {this.Slug}";
        }
    }
}
