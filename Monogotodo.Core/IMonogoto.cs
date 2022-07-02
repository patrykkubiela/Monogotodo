using Monogotodo.Core.Broadcasting;
using Monogotodo.Shared;

namespace Monogotodo.Core
{
    public interface IMonogoto : IObserver, IBroadcast
    {
        Guid Uuid { get; }
        string Name { get; set; }
        string Description { get; set; }
        MonogotoType Type { get; set; }
        IMonogoto Broadcaster { get; set; }

        IEnumerable<IMonogoto> GetBranch();
        IEnumerable<IMonogoto> GetWholeChain();
    }
}