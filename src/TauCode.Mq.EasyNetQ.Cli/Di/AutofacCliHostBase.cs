using Autofac;
using System;
using TauCode.Cli;

namespace TauCode.Mq.EasyNetQ.Cli.Lab.Di
{
    public abstract class AutofacCliHostBase : CliHostBase
    {
        protected AutofacCliHostBase(
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
