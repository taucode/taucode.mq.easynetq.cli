using System;
using TauCode.Mq.Abstractions;
using TauCode.Mq.EasyNetQ.Cli.Demo.Common;

namespace TauCode.Mq.EasyNetQ.Cli.Demo.Exe.MessageHandlers
{
    public class QuoteMessageTextHandler : MessageHandlerBase<QuoteMessage>
    {
        public override void Handle(QuoteMessage message)
        {
            Console.WriteLine("QUOTE:" + message.Quote);
        }
    }
}
