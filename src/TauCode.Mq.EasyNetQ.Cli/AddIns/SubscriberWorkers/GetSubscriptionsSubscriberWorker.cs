using Autofac;
using System;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class GetSubscriptionsSubscriberWorker : SubscriberWorkerBase
    {
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
            throw new NotImplementedException();
        }
    }
}
