using Autofac;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers
{
    public class StartPublisherWorker : AutofacCliWorkerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public StartPublisherWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(StartPublisherWorker)}.lisp", true),
                null,
                true)
        {
            _messagePublisher = this.LifetimeScope.Resolve<IMessagePublisher>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            _messagePublisher.Start();
        }
    }
}
