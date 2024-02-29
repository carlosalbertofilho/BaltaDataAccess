using Blog.Models;
using Blog.Repositories;
using Blog.Validation;

namespace Blog.Screens.PostScreens
{
    internal class UpdatePostScreen : UpdateEntityScreen<Post>
    {
        private readonly Repository<Post> _repository = new();
        private readonly Repository<User> _userRepository = new();
        private readonly Repository<Category> _categoryRepository = new();
        protected override void UpdateEntity()
        {
            ListEntitiesScreen<Post>.ListEntities();
            var id = InputHandler.GetId("Digite o Id do post: ");
            var post = GetPostById(id, _repository);
            if (post is null) return;
            HandlerOptions(_repository, post);

        }
        private void HandlerOptions(Repository<Post> repository, Post post)
        {
            Console.WriteLine("---------------------------\n\n");
            Console.WriteLine("O que vc deseja atualizar?");
            Console.WriteLine($"1 - Título: {post.Title} ? ");
            Console.WriteLine($"2 - Slug: {post.Slug} ? ");
            Console.WriteLine($"3 - Resumo: {post.Summary} ? ");
            Console.WriteLine($"4 - Conteúdo: {post.Body} ? ");
            Console.WriteLine($"5 - Autor: {_userRepository.Get(post.AuthorId)?.Name} ? ");
            Console.WriteLine($"6 - Categoria: {_categoryRepository.Get(post.CategoryId)?.Name} ? ");
            var option = InputHandler.GetOption();
            switch (option)
            {
                case 1:
                    Update(
                        UpdatePostTitle(post)
                      , "Título atualizado com sucesso"
                      , repository);
                    break;
                case 2:
                    Update(
                        UpdatePostSlug(post)
                      , "Slug atualizado com sucesso"
                      , repository);
                    break;
                case 3:
                    Update(
                        UpdatePostSummary(post)
                      , "Resumo atualizado com sucesso"
                      , repository);
                    break;
                case 4:
                    Update(
                        UpdatePostContent(post)
                      , "Conteúdo atualizado com sucesso"
                      , repository);
                    break;
                case 5:
                    Update(
                        UpdatePostAuthor(post)
                      , "Autor atualizado com sucesso"
                      , repository);
                    break;
                case 6:
                    Update(
                        UpdatePostCategory(post)
                      , "Categoria atualizada com sucesso"
                      , repository);
                    break;
                default:
                    Console.WriteLine("Operação cancelada");
                    break;
            }
        }

        private Post UpdatePostTitle(Post post)
        {
            Console.WriteLine("Digite o título do post: ");
            var title = Console.ReadLine();
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("O título do post é obrigatório");
            
            post.Title = title;
            return post;
        }
        private Post UpdatePostSlug(Post post)
        {
            Console.WriteLine("Digite o slug do post: ");
            var slug = Console.ReadLine();
            if (string.IsNullOrEmpty(slug))
                throw new ArgumentNullException("O slug do post é obrigatório");

            post.Slug = slug;
            return post;
        }
        private Post UpdatePostSummary(Post post)
        {
            Console.WriteLine("Digite o resumo do post: ");
            var summary = Console.ReadLine();
            if (string.IsNullOrEmpty(summary))
                throw new ArgumentNullException("O resumo do post é obrigatório");
            post.Summary = summary;
            post.LastUpdate = System.DateTime.Now;
            return post;
        }
        private Post UpdatePostContent(Post post)
        {
            Console.WriteLine("Digite o conteúdo do post: ");
            var content = Console.ReadLine();
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("O conteúdo do post é obrigatório");
            post.Body = content;
            post.LastUpdate = System.DateTime.Now;
            return post;
        }
        private Post UpdatePostAuthor(Post post)
        {
            ListAuthors();
            var authorId = InputHandler.GetId("Digite o Id do autor: ");
            if (authorId <= 0)
                throw new ArgumentNullException("O Id do autor é obrigatório");

            _ = new Repository<User>().Get(authorId) 
                ?? throw new ArgumentNullException("Id digitado invalido");

            post.AuthorId = authorId;
            post.LastUpdate = System.DateTime.Now;
            return post;
        }
        private static void ListAuthors()
        {
            var userRepository = new Repository<User>();
            Console.WriteLine("\n\n---------------------------");
            Console.WriteLine("Autores disponíveis: ");
            var users = userRepository.GetAll();
            users.ForEach(user
                => Console.WriteLine($"Id: {user.Id} - Nome: {user.Name}"));
            Console.WriteLine("---------------------------\n\n");
        }
        private Post UpdatePostCategory(Post post)
        {
            ListCategories();
            var categoryId = InputHandler.GetId("Digite o Id da categoria: ");
            if (categoryId <= 0)
                throw new ArgumentNullException("O Id da categoria é obrigatório");

            _ = new Repository<Category>().Get(categoryId) 
                ?? throw new ArgumentNullException("Id digitado invalido");
            
            post.CategoryId = categoryId;
            post.LastUpdate = System.DateTime.Now;
            return post;
        }
        private static void ListCategories()
        {
            var categoryRepository = new Repository<Category>();
            Console.WriteLine("\n\n---------------------------");
            Console.WriteLine("Tags disponíveis: ");
            var categories = categoryRepository.GetAll();
            categories.ForEach(category
                => Console.WriteLine($"Id: {category.Id} - Nome: {category.Name}"));
            Console.WriteLine("---------------------------\n\n");
        }
        private static void Update(Post post, string message, Repository<Post> repository)
        {
            repository.Update(post);
            Console.WriteLine(message);
        }
        private static Post GetPostById(int id, Repository<Post> repository)
        {
            var post = repository.Get(id);
            return post is null
                ? throw new ArgumentNullException("Post não encontrado")
                : post;
        }
    }
}