using Autofac;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli;
using TauCode.Mq.EasyNetQ.Cli.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    public class SubscriberAddIn : AutofacCliAddInBase
    {
        public SubscriberAddIn(ILifetimeScope lifetimeScope)
            : base(lifetimeScope, "sub", null, true)
        {
        }

        protected override IReadOnlyList<ICliWorker> CreateWorkers()
        {
            return this.LifetimeScope
                .GetTypesDerivedFrom<CliWorkerBase>()
                .Where(x => x.Name.EndsWith("SubscriberWorker"))
                .Select(t => (ICliWorker)this.LifetimeScope.Resolve(t))
                .ToList();
        }
    }
}
