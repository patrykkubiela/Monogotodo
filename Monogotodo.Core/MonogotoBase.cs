using Monogotodo.Shared;

namespace Monogotodo.Core
{
    public abstract class MonogotoBase : IMonogoto
    {
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MonogotoType Type { get; set; }
        public IMonogoto Broadcaster { get; set; }
        public List<IMonogoto> Observers { get; }


        protected MonogotoBase()
        {
            Uuid = Guid.NewGuid();
            Observers = new List<IMonogoto>();

            // Receive<Monogoto>(RegisterObserver);
        }

        public abstract void Receive();


        public virtual void RegisterObserver(IMonogoto observer)
        {
            Observers.Add(observer);
            observer.Broadcaster = this;
        }

        public virtual void UnregisterObserver(IMonogoto observer)
        {
            Observers.Remove(observer);
        }

        public virtual void Broadcast()
        {
            Observers.ForEach(o => o.Receive());
        }

        public IEnumerable<IMonogoto> GetBranch()
        {
            return Branch();
        }

        public IEnumerable<IMonogoto> GetWholeChain()
        {
            var result = new List<IMonogoto>();
            result.AddRange(Branch());
            result.AddRange(Chain());
            return result;
        }

        private IEnumerable<IMonogoto> GetObservers(IEnumerable<IMonogoto> observers)
        {
            var result = new List<IMonogoto>();

            foreach (var observer in observers)
            {
                result.Add(observer);
                result.AddRange(GetObservers(observer.Observers));
            }

            return result;
        }

        private IEnumerable<IMonogoto> Chain()
        {
            return GetBroadcasters(this);
        }

        private IEnumerable<IMonogoto> GetBroadcasters(IMonogoto observer)
        {
            var result = new List<IMonogoto>();
            if (observer?.Broadcaster != null)
            {
                result.Add(observer.Broadcaster);
                result.AddRange(GetBroadcasters(observer.Broadcaster));
            }

            return result;
        }

        private IEnumerable<IMonogoto> Branch()
        {
            var result = new List<IMonogoto>();
            result.Add(this);
            result.AddRange(GetObservers(Observers));
            return result;
        }
    }
}