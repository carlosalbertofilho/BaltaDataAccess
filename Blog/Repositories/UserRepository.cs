
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        /*
         * Docker Test C = 10.211.55.2
         * "Server=10.211.55.2,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
         * Docker Test H 
         * """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";
         */
        private const string CONNECTION_STRING
            = """Data Source=DESKTOP-4P9S4FF\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True; TrustServerCertificate=True;""";

        /// <summary>
        /// Reads all users from the database and prints their name and email.
        /// </summary>
        public void ReadUsers()
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var users = connection.GetAll<User>();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }


        /// <summary>
        /// Reads a user from the database based on the provided userId and prints their name and email.
        /// </summary>
        /// <param name="userId">The ID of the user to read.</param>
        public void ReadUser(int userId)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var user = connection.Get<User>(userId);
            Console.WriteLine($"{user.Name} - {user.Email}");
        }

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user object to create.</param>
        public void CreateUser(User user)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            connection.Insert(user);
            Console.WriteLine($"{user.Name} success insert!");
        }

        /// <summary>
        /// Updates a user in the database based on the provided userId.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="name">The new name of the user (optional).</param>
        /// <param name="email">The new email of the user (optional).</param>
        /// <param name="bio">The new bio of the user (optional).</param>
        /// <param name="passwordHash">The new password hash of the user (optional).</param>
        /// <param name="image">The new image URL of the user (optional).</param>
        /// <param name="slug">The new slug of the user (optional).</param>
        public void UpdateUser(
            int userId,
            string? name = null,
            string? email = null,
            string? bio = null,
            string? passwordHash = null,
            string? image = null,
            string? slug = null
        )
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var user = connection.Get<User>(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            user.Name = name ?? user.Name;
            user.Email = email ?? user.Email;
            user.Bio = bio ?? user.Bio;
            user.PasswordHash = passwordHash ?? user.PasswordHash;
            user.Image = image ?? user.Image;
            user.Slug = slug ?? user.Slug;

            connection.Update(user);
            Console.WriteLine($"{user.Name} success update!");
        }

        /// <summary>
        /// Deletes a user from the database based on the provided userId.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        public void DeleteUser(int userId)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var user = connection.Get<User>(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }
            connection.Delete(user);
            Console.WriteLine($"{user.Name} success delete!");
        }
    }
}
