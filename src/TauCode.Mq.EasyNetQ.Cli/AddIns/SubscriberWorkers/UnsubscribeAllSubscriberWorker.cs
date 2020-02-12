using Autofac;
using System;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class UnsubscribeAllSubscriberWorker : SubscriberWorkerBase
    {
        public UnsubscribeAllSubscriberWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(UnsubscribeAllSubscriberWorker)}.lisp", true),
                null,
                true)
        {
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            throw new NotImplementedException();
        }
    }
}
