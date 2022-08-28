
using Data.Core.Models;

namespace Data.Core.Repositories
{
    public interface IMonogotoRepository
    {
        Task<IList<Monogoto>> GetMonogotos();
        Task InsertMonogoto(Monogoto monogoto);
        Task<IList<Monogoto>> GetMonogotosByName(string name);
    }
}