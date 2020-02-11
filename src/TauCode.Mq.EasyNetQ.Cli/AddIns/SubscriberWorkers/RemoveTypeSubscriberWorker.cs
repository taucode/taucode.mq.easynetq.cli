using Autofac;
using System;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class RemoveTypeSubscriberWorker : AutofacCliWorkerBase
    {
        private readonly IMessageSubscriber _messageSubscriber;

        public RemoveTypeSubscriberWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(RemoveTypeSubscriberWorker)}.lisp", true),
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
