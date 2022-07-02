using Monogotodo.Data.Models;

namespace Monogotodo.Data.Repositories
{
    public interface IMonogotoRepository
    {
        ICollection<Monogoto> GetMonogotos(string query);
    }
}