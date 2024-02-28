
using Blog.Repositories;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Summary { get; set; }
        public string? Body { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }

        override public string ToString()
        {
            return $"Post: {Id}" +
                $"\n\tTitulo: {Title}" +
                $"\n\tAutor: {GetAuthorName(AuthorId)}" +
                $"\n\tCategoria: {GetCategoryName(CategoryId)}" +
                $"\n\tCriado em: {CreatedAt}" +
                $"\n\tUltima atualização: {LastUpdate}";
        }

        private static string? GetAuthorName(int id)
        {
            var repository = new Repository<User>();
            var user = repository.Get(id);
            return user != null
                ? user.Name
                : string.Empty;
        }
        private static string? GetCategoryName(int id)
        {
            var repository = new Repository<Category>();
            var category = repository.Get(id);
            return category != null
                ? category.Name
                : string.Empty;
        }
    }
}
