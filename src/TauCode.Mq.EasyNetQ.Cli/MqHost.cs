using Autofac;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli;
using TauCode.Mq.EasyNetQ.Cli.Di;

namespace TauCode.Mq.EasyNetQ.Cli
{
    // todo clean
    public class MqHost : AutofacCliHostBase
    {
        //private readonly PublisherAddIn _publisherAddIn;
        //private readonly SubscriberAddIn _subscriberAddIn;

        public MqHost(ILifetimeScope lifetimeScope)
            : base(lifetimeScope, "mqhost", "1.0", true)
        {
            //_publisherAddIn = publisherAddIn;
            //_subscriberAddIn = subscriberAddIn;
        }

        protected override IReadOnlyList<ICliAddIn> CreateAddIns()
        {
            //var regs = this.LifetimeScope.ComponentRegistry.Registrations;
            //throw new NotImplementedException();

            return this.LifetimeScope
                .GetTypesDerivedFrom<CliAddInBase>()
                .Select(t => (ICliAddIn)this.LifetimeScope.Resolve(t))
                .ToList();
        }
    }
}
