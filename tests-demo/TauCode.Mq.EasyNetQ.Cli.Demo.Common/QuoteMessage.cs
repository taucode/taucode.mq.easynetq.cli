using System;
using TauCode.Mq.Abstractions;

namespace TauCode.Mq.EasyNetQ.Cli.Demo.Common
{
    public class QuoteMessage : IMessage
    {
        public QuoteMessage()
        {
        }

        public QuoteMessage(decimal quote)
        {
            this.Quote = quote;
            this.CreatedAt = DateTime.UtcNow;
        }

        public decimal Quote { get; set; }

        public string CorrelationId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
