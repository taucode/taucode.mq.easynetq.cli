using System.Collections.Generic;
using Autofac;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherExecutors
{
    public class StopPublisherExecutor : PublisherExecutorBase
    {
        public StopPublisherExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($"{nameof(StopPublisherExecutor)}.lisp", true),
                null,
                true)
        {
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            this.MessagePublisher.Stop();
        }
    }
}
