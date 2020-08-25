using Autofac;
using TauCode.Mq.EasyNetQ.Cli.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    public abstract class PublisherExecutorBase : AutofacCliExecutorBase
    {
        protected PublisherExecutorBase(
            ILifetimeScope lifetimeScope,
            string grammar,
            string version,
            bool supportsHelp)
            : base(lifetimeScope, grammar, version, supportsHelp)
        {
            this.MessagePublisher = this.LifetimeScope.Resolve<IMessagePublisher>();
        }

        protected IMessagePublisher MessagePublisher { get; }
    }
}
