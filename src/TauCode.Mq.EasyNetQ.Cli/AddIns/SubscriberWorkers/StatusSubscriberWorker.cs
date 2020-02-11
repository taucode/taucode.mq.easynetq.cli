using Autofac;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class StatusSubscriberWorker : AutofacCliWorkerBase
    {
        private readonly IMessageSubscriber _messageSubscriber;

        public StatusSubscriberWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(StatusSubscriberWorker)}.lisp", true),
                null,
                true)
        {
            _messageSubscriber = this.LifetimeScope.Resolve<IMessageSubscriber>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var status = _messageSubscriber.State;
            this.Output.WriteLine(status.ToString());
        }
    }
}
