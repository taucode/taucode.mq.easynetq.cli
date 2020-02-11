using Autofac;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli;
using TauCode.Mq.EasyNetQ.Cli.Di;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    // todo clean
    public class PublisherAddIn : AutofacCliAddInBase
    {
        //private readonly GetPublisherStatusWorker _getPublisherStatusWorker;
        //private readonly PublishMessagePublisherWorker _publishMessagePublisherWorker;
        //private readonly StartPublisherWorker _startPublisherWorker;
        //private readonly StopPublisherWorker _stopPublisherWorker;

        public PublisherAddIn(
            ILifetimeScope lifetimeScope
            //GetPublisherStatusWorker getPublisherStatusWorker,
            //PublishMessagePublisherWorker publishMessagePublisherWorker,
            //StartPublisherWorker startPublisherWorker,
            //StopPublisherWorker stopPublisherWorker
            )
            : base(lifetimeScope, "pub", null, true)
        {
            //_getPublisherStatusWorker = getPublisherStatusWorker;
            //_publishMessagePublisherWorker = publishMessagePublisherWorker;
            //_startPublisherWorker = startPublisherWorker;
            //_stopPublisherWorker = stopPublisherWorker;
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
