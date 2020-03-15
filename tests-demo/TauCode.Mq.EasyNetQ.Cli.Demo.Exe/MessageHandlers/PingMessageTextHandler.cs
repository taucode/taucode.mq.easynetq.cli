using System;
using TauCode.Mq.Abstractions;
using TauCode.Mq.EasyNetQ.Cli.Demo.Common;

namespace TauCode.Mq.EasyNetQ.Cli.Demo.Exe.MessageHandlers
{
    public class PingMessageTextHandler : MessageHandlerBase<PingMessage>
    {
        public override void Handle(PingMessage message)
        {
            Console.WriteLine("TAG:" + message.Tag);
        }
    }
}
