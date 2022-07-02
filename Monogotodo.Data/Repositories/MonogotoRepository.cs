using Monogotodo.Data.Models;

namespace Monogotodo.Data.Repositories
{
    public class MonogotoRepository : IMonogotoRepository
    {
        public ICollection<Monogoto> GetMonogotos(string query)
        {
            return Array.Empty<Monogoto>();
        }
    }
}