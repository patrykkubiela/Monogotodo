using Akka.Actor;

namespace Monogotodo.Core
{
    public class MonogotoActor : ReceiveActor
    {
        public MonogotoActor()
        {
            Receive<Monogoto>(crumb =>
            {
                Console.WriteLine($"Name of crumb: ");
            });
        }
    }
}