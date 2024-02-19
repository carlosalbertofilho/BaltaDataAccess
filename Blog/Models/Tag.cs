﻿
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Tag]")]
    public class Tag
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public DateTime CreatedAt { get; set; }

        [Write(false)]
        public List<Post> Posts { get; set; } = [];

        public override string ToString()
        {
            return $"{this.Id} - {this.Name} - {this.Slug}";
        }
    }
}
