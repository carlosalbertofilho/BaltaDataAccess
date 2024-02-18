

using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    /// <summary>
    /// Class responsible for accessing the Role table data in the database.
    /// </summary>
    public class RoleRepository(SqlConnection connection)
    {
        private readonly SqlConnection _connection = connection;

        /// <summary>
        /// Gets all roles from the database.
        /// </summary>
        /// <returns>List of roles.</returns>
        public List<Role> GetRoles()
            => (List<Role>)_connection.GetAll<Role>();

        /// <summary>
        /// Gets a role by its ID.
        /// </summary>
        /// <param name="id">Role ID.</param>
        /// <returns>The found role or null if it doesn't exist.</returns>
        public Role GetRole(int id)
            => _connection.Get<Role>(id);

        /// <summary>
        /// Creates a new role in the database.
        /// </summary>
        /// <param name="role">Role to be created.</param>
        /// <returns>The ID of the created role.</returns>
        public long Create(Role role)
            => _connection.Insert(role);

        /// <summary>
        /// Updates a role in the database.
        /// </summary>
        /// <param name="role">Role to be updated.</param>
        /// <returns>True if the update is successful, False otherwise.</returns>
        public bool Update(Role role)
            => _connection.Update(role);

        /// <summary>
        /// Deletes a role from the database.
        /// </summary>
        /// <param name="roleId">The ID of the role to delete.</param>
        /// <returns>True if the deletion is successful, False otherwise.</returns>
        public bool Delete(int roleId)
            => _connection.Delete(_connection.Get<Role>(roleId));
    }
}
