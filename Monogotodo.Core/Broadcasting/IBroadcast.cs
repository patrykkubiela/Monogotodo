using System.Collections.Generic;

namespace Monogotodo.Core.Broadcasting
{
    public interface IBroadcast
    {
        List<IMonogoto> Observers { get; }
        
        void RegisterObserver(IMonogoto observer);
        void UnregisterObserver(IMonogoto observer);
        void Broadcast();
    }
}