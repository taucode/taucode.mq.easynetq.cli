using Autofac;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli;
using TauCode.Mq.EasyNetQ.Cli.Di;

namespace TauCode.Mq.EasyNetQ.Cli
{
    public class MqHost : AutofacCliHostBase
    {
        public MqHost(ILifetimeScope lifetimeScope)
            : base(lifetimeScope, "mqhost", "1.0", true)
        {
        }

        protected override IReadOnlyList<ICliAddIn> CreateAddIns()
        {
            return this.LifetimeScope
                .GetTypesDerivedFrom<CliAddInBase>()
                .Select(t => (ICliAddIn)this.LifetimeScope.Resolve(t))
                .ToList();
        }
    }
}
