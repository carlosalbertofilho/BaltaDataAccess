
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository(SqlConnection connection) : Repository<User>(connection)
    {
        private readonly SqlConnection _connection = connection;

        public List<User> GetAllUserWithRoles()
        {
            var query = @"
            SELECT
                [User].*,
                [Role].*
            FROM
                [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query
                , (user, role) =>
                {
                    var existingUser = users.FirstOrDefault(u => u.Id == user.Id);

                    if (existingUser is null)
                    {
                        existingUser = user;

                        if (role is not null) 
                            existingUser.Roles.Add(role);

                        users.Add(existingUser);
                    }
                    else
                        if (role is not null) 
                            existingUser.Roles.Add(role);

                    return existingUser;
                }
                , splitOn: "Id");

            return users;
        }
    }
}
