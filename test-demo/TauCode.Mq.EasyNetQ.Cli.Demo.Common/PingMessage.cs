using System;
using TauCode.Mq.Abstractions;

namespace TauCode.Mq.EasyNetQ.Cli.Demo.Common
{
    public class PingMessage : IMessage
    {
        public PingMessage()
        {
        }

        public PingMessage(int tag)
        {
            this.Tag = tag;
            this.CreatedAt = DateTime.UtcNow;
        }

        public int Tag { get; set; }

        public string Topic { get; set; }
        public string CorrelationId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
