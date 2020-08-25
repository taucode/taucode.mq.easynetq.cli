using System.Collections.Generic;
using Autofac;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberExecutors
{
    public class StartSubscriberExecutor : SubscriberExecutorBase
    {
        public StartSubscriberExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(StartSubscriberExecutor)}.lisp", true),
                null,
                true)
        {
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            this.MessageSubscriber.Start();
        }
    }
}
