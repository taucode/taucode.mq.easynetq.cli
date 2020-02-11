using TauCode.Mq.EasyNetQ.Cli.Demo.Common;

namespace TauCode.Mq.EasyNetQ.Cli.Demo.Exe
{
    internal class Program : MqProgramBase
    {
        public Program()
            : base(
                new[]
                {
                    typeof(HelloMessage),
                    typeof(PingMessage),
                    typeof(QuoteMessage),
                },
                new[]
                {
                    typeof(HelloMessage),
                    typeof(PingMessage),
                    typeof(QuoteMessage),
                },
                "host=localhost")
        {
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Init();
            program.Run();
        }
    }
}
