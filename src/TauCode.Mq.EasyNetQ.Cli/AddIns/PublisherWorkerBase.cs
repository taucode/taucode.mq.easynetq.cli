using Autofac;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns
{
    public abstract class PublisherWorkerBase : AutofacCliWorkerBase
    {
        protected PublisherWorkerBase(
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
