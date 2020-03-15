using Autofac;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli;
using TauCode.Mq.EasyNetQ.Cli.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    public class PublisherAddIn : AutofacCliAddInBase
    {
        public PublisherAddIn(ILifetimeScope lifetimeScope)
            : base(lifetimeScope, "pub", null, true)
        {
            this.Description = "Provides functionality for publishing messages.";
        }

        protected override IReadOnlyList<ICliWorker> CreateWorkers()
        {
            return this.LifetimeScope
                .GetTypesDerivedFrom<CliWorkerBase>()
                .Where(x => x.Name.EndsWith("PublisherWorker"))
                .Select(t => (ICliWorker)this.LifetimeScope.Resolve(t))
                .ToList();
        }
    }
}
