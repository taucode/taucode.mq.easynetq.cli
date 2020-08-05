using System;
using TauCode.Mq.Abstractions;
using TauCode.Mq.EasyNetQ.Cli.Demo.Common;

namespace TauCode.Mq.EasyNetQ.Cli.Demo.Exe.MessageHandlers
{
    public class HelloMessageTextHandler : MessageHandlerBase<HelloMessage>
    {
        public override void Handle(HelloMessage message)
        {
            Console.WriteLine("GREETING:" + message.Greeting);
        }
    }
}
