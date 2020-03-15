using Newtonsoft.Json;
using System;
using TauCode.Mq.Abstractions;

namespace TauCode.Mq.EasyNetQ.Cli
{
    public class JsonMessageHandler<TMessage> : MessageHandlerBase<TMessage> where TMessage : IMessage
    {
        public override void Handle(TMessage message)
        {
            var json = JsonConvert.SerializeObject(message);
            Console.WriteLine(json);
        }
    }
}
