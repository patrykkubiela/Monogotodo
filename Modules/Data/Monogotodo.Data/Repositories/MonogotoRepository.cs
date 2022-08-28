using MongoDB.Driver;
using Monogotodo.Data.Models;

namespace Monogotodo.Data.Repositories
{
    public class  MonogotoRepository : IMonogotoRepository
    {
        private readonly IMongoCollection<Monogoto> _monogotoCollection;

        public MonogotoRepository(IMongoDatabase mongoDatabase)
        {
            _monogotoCollection = mongoDatabase.GetCollection<Monogoto>("monogoto");
        }
        
        public async Task<IList<Monogoto>> GetMonogotos()
        {
            return await _monogotoCollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertMonogoto(Monogoto monogoto)
        {
            await _monogotoCollection.InsertOneAsync(monogoto);
        }

        public async Task<IList<Monogoto>> GetMonogotosByName(string name)
        {
            var list = await _monogotoCollection.Find(x => x.Name == name)
                .ToListAsync();
            return list;
        }
    }
}