using Autofac;
using TauCode.Mq.EasyNetQ.Cli.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    public abstract class SubscriberExecutorBase : AutofacCliExecutorBase
    {
        protected SubscriberExecutorBase(
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
