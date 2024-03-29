﻿
using Azure;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Tag]")]
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public DateTime CreatedAt { get; set; }

        [Write(false)]
        public List<Post> Posts { get; set; } = [];

        public override string ToString()
        {
            return $"Id: {this.Id} | Título: {this.Name} | Slug: {this.Slug}";
        }
    }
}
