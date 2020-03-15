using System;
using TauCode.Mq.Abstractions;

namespace TauCode.Mq.EasyNetQ.Cli.Demo.Common
{
    public class HelloMessage : IMessage
    {
        public HelloMessage()
        {
        }

        public HelloMessage(string greeting)
        {
            this.Greeting = greeting;
            this.CreatedAt = DateTime.UtcNow;
        }

        public string Greeting { get; set; }

        public string CorrelationId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
