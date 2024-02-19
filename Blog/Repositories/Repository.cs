

using Blog.DB;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    /// <summary>
    /// Represents a generic repository for a specific model type.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class Repository<TModel>() where TModel : class
    {

        /// <summary>
        /// Gets all the models from the repository.
        /// </summary>
        /// <returns>A list of all the models.</returns>
        public List<TModel> GetAll()
            => (List<TModel>)Database.Connection.GetAll<TModel>();

        /// <summary>
        /// Gets a model by its ID.
        /// </summary>
        /// <param name="id">The ID of the model.</param>
        /// <returns>The model with the specified ID.</returns>
        public TModel Get(int id)
            => Database.Connection.Get<TModel>(id);

        /// <summary>
        /// Creates a new model in the repository.
        /// </summary>
        /// <param name="model">The model to create.</param>
        /// <returns>The ID of the created model.</returns>
        public long Create(TModel model)
            => Database.Connection.Insert(model);

        /// <summary>
        /// Updates an existing model in the repository.
        /// </summary>
        /// <param name="model">The model to update.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        public bool Update(TModel model)
            => Database.Connection.Update(model);

        /// <summary>
        /// Deletes a model from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the model to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        public bool Delete(int id)
            => Database.Connection.Delete(Database.Connection.Get<TModel>(id));
    }
}
