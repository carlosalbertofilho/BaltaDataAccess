

using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    /// <summary>
    /// Represents a generic repository for a specific model type.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class Repository<TModel>(SqlConnection connection) where TModel : class
    {
        private readonly SqlConnection _connection = connection;

        /// <summary>
        /// Gets all the models from the repository.
        /// </summary>
        /// <returns>A list of all the models.</returns>
        public List<TModel> GetAll()
            => (List<TModel>)_connection.GetAll<TModel>();

        /// <summary>
        /// Gets a model by its ID.
        /// </summary>
        /// <param name="id">The ID of the model.</param>
        /// <returns>The model with the specified ID.</returns>
        public TModel Get(int id)
            => _connection.Get<TModel>(id);

        /// <summary>
        /// Creates a new model in the repository.
        /// </summary>
        /// <param name="model">The model to create.</param>
        /// <returns>The ID of the created model.</returns>
        public long Create(TModel model)
            => _connection.Insert(model);

        /// <summary>
        /// Updates an existing model in the repository.
        /// </summary>
        /// <param name="model">The model to update.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        public bool Update(TModel model)
            => _connection.Update(model);

        /// <summary>
        /// Deletes a model from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the model to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        public bool Delete(int id)
            => _connection.Delete(_connection.Get<TModel>(id));
    }
}
