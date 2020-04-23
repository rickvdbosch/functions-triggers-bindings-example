using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage.Table;

namespace ExampleFunctionProject.Helpers
{
    public static class TableStorageHelper
    {
        /// <summary>
        /// Gets all entities of type <typeparamref name="T"/> from <paramref name="table"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity to get.</typeparam>
        /// <param name="table">The <see cref="CloudTable"/> to get the entities from.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing all entities of type <typeparamref name="T"/> 
        /// from <paramref name="table"/>.
        /// </returns>
        public static async Task<IEnumerable<T>> GetEntitiesFromTable<T>(CloudTable table) where T : ITableEntity, new()
        {
            TableQuerySegment<T> querySegment = null;
            var entities = new List<T>();
            var query = new TableQuery<T>();

            do
            {
                querySegment = await table.ExecuteQuerySegmentedAsync(query, querySegment?.ContinuationToken);
                entities.AddRange(querySegment.Results);
            } while (querySegment.ContinuationToken != null);

            return entities;
        }
    }
}
