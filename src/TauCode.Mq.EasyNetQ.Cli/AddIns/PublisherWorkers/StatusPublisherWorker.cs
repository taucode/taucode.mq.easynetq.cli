using Autofac;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers
{
    public class StatusPublisherWorker : AutofacCliWorkerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public StatusPublisherWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(StatusPublisherWorker)}.lisp", true),
                null,
                true)
        {
            _messagePublisher = this.LifetimeScope.Resolve<IMessagePublisher>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var status = _messagePublisher.State;
            this.Output.WriteLine(status.ToString());
        }
    }
}
