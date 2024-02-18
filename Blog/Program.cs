
using Blog.Models;
using Blog.Repositories;

UserRepository userRepository = new();

userRepository.GetUsers()?.ForEach(user => Console.WriteLine(user));

Console.WriteLine("\n-------------\n");
Console.WriteLine(userRepository.GetUser(1));

Console.WriteLine("\n-------------\n");
//userRepository.CreateUser(new User
//{
//    Name = "Equipe Blog"
//,   Email = "equipe@teste.com"
//,   Bio  = "Equipe do Blog"
//,   PasswordHash = "HASH"
//,   Image = "https://th.bing.com/th/id/OIP.XfN_dUTzgeHXLeHD9DK0uwAAAA?rs=1&pid=ImgDetMain"
//,   Slug = "equipe-blog"
//,   CreatedAt = DateTime.Now
//});
//Console.WriteLine("\n-------------\n");
userRepository.UpdateUser(15, name: "Equipe Blog | Suporte", bio: "Equipe de suporte");

