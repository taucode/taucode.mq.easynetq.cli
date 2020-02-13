using Autofac;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class GetSubscriptionsSubscriberWorker : SubscriberWorkerBase
    {
        private class SubscriptionInfoDto
        {
            public string MessageTypeFullName { get; set; }
            public string Topic { get; set; }
            public string HandlerTypeFullName { get; set; }
        }

        public GetSubscriptionsSubscriberWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(GetSubscriptionsSubscriberWorker)}.lisp", true),
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
                    HandlerTypeFullName = x.HandlerType.FullName,
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
