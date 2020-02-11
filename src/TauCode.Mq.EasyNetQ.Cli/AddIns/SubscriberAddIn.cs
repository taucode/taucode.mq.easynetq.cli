using Autofac;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli;
using TauCode.Mq.EasyNetQ.Cli.Di;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    public class SubscriberAddIn : AutofacCliAddInBase
    {
        //private readonly GetSubscriberStatusWorker _getSubscriberStatusWorker;
        //private readonly StartSubscriberWorker _startSubscriberWorker;
        //private readonly StopSubscriberWorker _stopSubscriberWorker;
        //private readonly SubscribeToMessageSubscriberWorker _subscribeToMessageSubscriberWorker;
        //private readonly UnsubscribeFromMessageSubscriberWorker _unsubscribeFromMessageSubscriberWorker;

        public SubscriberAddIn(
            ILifetimeScope lifetimeScope
            //GetSubscriberStatusWorker getSubscriberStatusWorker,
            //StartSubscriberWorker startSubscriberWorker,
            //StopSubscriberWorker stopSubscriberWorker,
            //SubscribeToMessageSubscriberWorker subscribeToMessageSubscriberWorker,
            //UnsubscribeFromMessageSubscriberWorker unsubscribeFromMessageSubscriberWorker
            )
            : base(lifetimeScope, "sub", null, true)
        {
            //_getSubscriberStatusWorker = getSubscriberStatusWorker;
            //_startSubscriberWorker = startSubscriberWorker;
            //_stopSubscriberWorker = stopSubscriberWorker;
            //_subscribeToMessageSubscriberWorker = subscribeToMessageSubscriberWorker;
            //_unsubscribeFromMessageSubscriberWorker = unsubscribeFromMessageSubscriberWorker;
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
