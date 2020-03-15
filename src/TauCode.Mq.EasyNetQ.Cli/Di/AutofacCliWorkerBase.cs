using Autofac;
using System;
using TauCode.Cli;

namespace TauCode.Mq.EasyNetQ.Cli.Di
{
    public abstract class AutofacCliWorkerBase : CliWorkerBase
    {
        protected AutofacCliWorkerBase(
            ILifetimeScope lifetimeScope,
            string grammar,
            string version,
            bool supportsHelp)
            : base(grammar, version, supportsHelp)
        {
            this.LifetimeScope = lifetimeScope ?? throw new ArgumentNullException(nameof(lifetimeScope));
        }

        public ILifetimeScope LifetimeScope { get; }
    }
}
