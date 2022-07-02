using Akka.Actor;

namespace Monogotodo.Core
{
    public class MonogotoActor : ReceiveActor
    {
        public MonogotoActor()
        {
            Receive<Monogoto>(monogoto =>
            {
                Console.WriteLine($"Name of crumb: ");
            });
        }
    }
}