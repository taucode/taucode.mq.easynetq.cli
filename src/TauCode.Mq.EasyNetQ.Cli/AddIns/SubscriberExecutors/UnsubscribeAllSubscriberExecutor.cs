using System;
using Autofac;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberExecutors
{
    public class UnsubscribeAllSubscriberExecutor : SubscriberExecutorBase
    {
        public UnsubscribeAllSubscriberExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(UnsubscribeAllSubscriberExecutor)}.lisp", true),
                null,
                true)
        {
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            throw new NotImplementedException();

            //this.MessageSubscriber.UnsubscribeAll();
        }
    }
}
