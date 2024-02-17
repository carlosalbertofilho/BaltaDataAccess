
namespace Blog.Models
{
    internal class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Summary { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
        public User? Author { get; set; }
    }
}
