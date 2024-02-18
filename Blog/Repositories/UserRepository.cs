
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository(SqlConnection connection)
    {

        private readonly SqlConnection _connection = connection;


        /// <summary>
        /// Reads all users from the database and prints their name and email.
        /// </summary>
        public List<User> GetUsers()
            => (List<User>)_connection.GetAll<User>();


        /// <summary>
        /// Reads a user from the database based on the provided userId and prints their name and email.
        /// </summary>
        /// <param name="userId">The ID of the user to read.</param>
        public User? GetUser(int userId)
            => _connection.Get<User>(userId);

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user object to create.</param>
        public long Create(User user)
            => _connection.Insert(user);

        /// <summary>
        /// Updates a user in the database based on the provided userId.
        /// </summary>
        /// <param name="user">The updated user object.</param>
        /// <returns>True if the user was successfully updated, false otherwise.</returns>
        public bool Update(User user)
            => _connection.Update(user);

        /// <summary>
        /// Deletes a user from the database based on the provided userId.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>True if the user was successfully deleted, false otherwise.</returns>
        public bool Delete(int userId)
            => _connection.Delete(_connection.Get<User>(userId));
    }
}
