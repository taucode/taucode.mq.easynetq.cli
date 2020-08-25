using System.Collections.Generic;
using System.Linq;
using Autofac;
using Newtonsoft.Json;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberExecutors
{
    public class GetSubscriptionsSubscriberExecutor : SubscriberExecutorBase
    {
        private class SubscriptionInfoDto
        {
            public string MessageTypeFullName { get; set; }
            public string Topic { get; set; }
            public string HandlerTypeFullName { get; set; }
        }

        public GetSubscriptionsSubscriberExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(GetSubscriptionsSubscriberExecutor)}.lisp", true),
                null,
                true)
        {
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var subscriptions = this.MessageSubscriber
                .GetSubscriptions()
                .Select(x => new SubscriptionInfoDto
                {
                    MessageTypeFullName = x.MessageType.FullName,
                    Topic = x.Topic,
                    HandlerTypeFullName = x.MessageHandlerType.FullName,
                })
                .Select(x => JsonConvert.SerializeObject(x, Formatting.Indented))
                .ToList();

            foreach (var subscription in subscriptions)
            {
                this.Output.WriteLine(subscription);
            }
        }
    }
}
