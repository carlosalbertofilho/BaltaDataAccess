﻿

using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public DateTime CreatedAt { get; set; }

        [Write(false)]
        public List<Post> Posts { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {Id} | Nome: {Name} | Slug: {Slug}";
        }
    }
}
