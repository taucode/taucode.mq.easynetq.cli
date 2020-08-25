using System.Collections.Generic;
using Autofac;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberExecutors
{
    public class StopSubscriberExecutor : SubscriberExecutorBase
    {
        public StopSubscriberExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(StopSubscriberExecutor)}.lisp", true),
                null,
                true)
        {
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            this.MessageSubscriber.Stop();
        }
    }
}
