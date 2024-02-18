﻿
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
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="name">The new name of the user (optional).</param>
        /// <param name="email">The new email of the user (optional).</param>
        /// <param name="bio">The new bio of the user (optional).</param>
        /// <param name="passwordHash">The new password hash of the user (optional).</param>
        /// <param name="image">The new image URL of the user (optional).</param>
        /// <param name="slug">The new slug of the user (optional).</param>
        public bool Update(
            int userId,
            string? name = null,
            string? email = null,
            string? bio = null,
            string? passwordHash = null,
            string? image = null,
            string? slug = null
        )
        {
            var user = _connection.Get<User>(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return false;
            }

            user.Name = name ?? user.Name;
            user.Email = email ?? user.Email;
            user.Bio = bio ?? user.Bio;
            user.PasswordHash = passwordHash ?? user.PasswordHash;
            user.Image = image ?? user.Image;
            user.Slug = slug ?? user.Slug;

            return _connection.Update(user);
        }

        /// <summary>
        /// Deletes a user from the database based on the provided userId.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        public bool Delete(int userId)
            => _connection.Delete(_connection.Get<User>(userId));
    }
}