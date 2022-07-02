using Monogotodo.Shared;

namespace Monogotodo.Data.Models
{
    public class Monogoto
    {
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MonogotoType Type { get; set; }
        public Monogoto Broadcaster { get; set; }
        public ICollection<Monogoto> Observers { get; }
    }
}