using MongoDB.Bson;
using MongoDB.Driver;
using NetPress.Application.Contracts.Persistence;

namespace NetPress.Persistence.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public AsyncRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", new ObjectId(id.ToString()))).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id.ToString())), entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", new ObjectId(id.ToString())));
        }
    }
}
