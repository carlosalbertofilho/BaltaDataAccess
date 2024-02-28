using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.PostScreens
{
    internal class CreatePostScreen : CreateEntityScreen<Post>
    {
        private readonly Repository<Post> _repository = new();
        private readonly Repository<User> _userRepository = new();
        private readonly Repository<Category> _categoryRepository = new();
        protected override void CreateEntity()
        {
            var post = new Post
            {
                Title = GetPostTitle(),
                Slug = GetPostSlug(),
                Summary = GetPostSummary(),
                Body = GetPostContent(),
                AuthorId = GetAuthorId(),
                CategoryId = GetCategoryId(),
                CreatedAt = System.DateTime.Now,
                LastUpdate = System.DateTime.Now
            };
            _repository.Create(post);
            Console.WriteLine($"Post: = {post.Title},  cadastrado com sucesso!");

        }

        private static string GetPostTitle()
        {
            Console.WriteLine("Digite o título do post: ");
            var title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("O título do post é obrigatório");
            return title;
        }

        private static string GetPostSlug()
        {
            Console.WriteLine("Digite o slug do post: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("O slug do post é obrigatório");
            return slug;
        }

        private static string GetPostSummary()
        {
            Console.WriteLine("Digite o resumo do post: ");
            var summary = Console.ReadLine();
            if (string.IsNullOrEmpty(summary))
                throw new ArgumentNullException("O resumo do post é obrigatório");
            return summary;
        }

        private static string GetPostContent()
        {
            Console.WriteLine("Digite o conteúdo do post: ");
            var content = Console.ReadLine();
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("O conteúdo do post é obrigatório");
            return content;
        }

        private int GetAuthorId()
        {
            ListAuthors(_userRepository);
            var authorId = InputHandler.GetId("Digite o id do autor: ");
            if (authorId == 0) this.Load();
            return authorId;
        }

        private int GetCategoryId()
        {
            ListCategories(_categoryRepository);
            var tagId = InputHandler.GetId("Digite o id da category: ");
            if (tagId == 0) this.Load();
            return tagId;
        }

        private static void ListAuthors(Repository<User> userRepository)
        {
            Console.WriteLine("\n\n---------------------------");
            Console.WriteLine("Autores disponíveis: ");
            var users = userRepository.GetAll();
            users.ForEach(user 
                => Console.WriteLine($"Id: {user.Id} - Nome: {user.Name}"));
            Console.WriteLine("---------------------------\n\n");
        }

        private static void ListCategories(Repository<Category> categoryRepository)
        {
            Console.WriteLine("\n\n---------------------------");
            Console.WriteLine("Tags disponíveis: ");
            var categories = categoryRepository.GetAll();
            categories.ForEach(category 
                => Console.WriteLine($"Id: {category.Id} - Nome: {category.Name}"));
            Console.WriteLine("---------------------------\n\n");
        }
    }
}