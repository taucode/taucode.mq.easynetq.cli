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
            this.Description = "Provides functionality for subscription to messages.";
        }


        protected override IReadOnlyList<ICliExecutor> CreateExecutors()
        {
            return this.LifetimeScope
                .GetTypesDerivedFrom<CliExecutorBase>()
                .Where(x => x.Name.EndsWith("SubscriberExecutor"))
                .Select(t => (ICliExecutor)this.LifetimeScope.Resolve(t))
                .ToList();
        }
    }
}
