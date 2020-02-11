using Autofac;
using System;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class StartSubscriberWorker : AutofacCliWorkerBase
    {
        private readonly IMessageSubscriber _messageSubscriber;

        public StartSubscriberWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(StartSubscriberWorker)}.lisp", true),
                null,
                true)
        {
            _messageSubscriber = this.LifetimeScope.Resolve<IMessageSubscriber>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            throw new NotImplementedException();
        }
    }
}
