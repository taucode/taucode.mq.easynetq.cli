using Autofac;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    public abstract class SubscriberWorkerBase : AutofacCliWorkerBase
    {
        protected SubscriberWorkerBase(
            ILifetimeScope lifetimeScope,
            string grammar,
            string version,
            bool supportsHelp)
            : base(lifetimeScope, grammar, version, supportsHelp)
        {
            this.MessageSubscriber = this.LifetimeScope.Resolve<IMessageSubscriber>();
        }

        protected IMessageSubscriber MessageSubscriber { get; }
    }
}
