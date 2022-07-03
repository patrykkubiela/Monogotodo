using MongoDB.Driver;
using Monogotodo.Data.Models;

namespace Monogotodo.Data.Repositories
{
    public class MonogotoRepository : IMonogotoRepository
    {
        private readonly IMongoCollection<Monogoto> _monogotoCollection;

        public MonogotoRepository(IMongoDatabase mongoDatabase)
        {
            _monogotoCollection = mongoDatabase.GetCollection<Monogoto>("monogoto");
        }
        
        public async Task<IList<Monogoto>> GetMonogotos(string query)
        {
            return await _monogotoCollection.Find(_ => true).ToListAsync();
        }
    }
}