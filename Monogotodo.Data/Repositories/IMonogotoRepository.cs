using Monogotodo.Data.Models;

namespace Monogotodo.Data.Repositories
{
    public interface IMonogotoRepository
    {
        Task<IList<Monogoto>> GetMonogotos();
        Task InsertMonogoto(Monogoto monogoto);
    }
}