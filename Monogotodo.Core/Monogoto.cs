namespace Monogotodo.Core
{
    public class Monogoto : MonogotoBase
    {
        public override void Receive()
        {
            Console.Write("this is message from within crumb");
        }
    }
}