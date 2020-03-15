using Autofac;
using System;
using TauCode.Cli;

namespace TauCode.Mq.EasyNetQ.Cli.Di
{
    public abstract class AutofacCliAddInBase : CliAddInBase
    {
        protected AutofacCliAddInBase(ILifetimeScope lifetimeScope)
        {
            this.LifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        protected AutofacCliAddInBase(
            ILifetimeScope lifetimeScope,
            string name,
            string version,
            bool supportsHelp)
            : base(name, version, supportsHelp)
        {
            this.LifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        public ILifetimeScope LifetimeScope { get; }
    }
}
