using System.Collections.Generic;
using Autofac;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherExecutors
{
    public class MessageTypesPublisherExecutor : PublisherExecutorBase
    {
        private readonly MqProgramBase _mqProgram;

        public MessageTypesPublisherExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(MessageTypesPublisherExecutor)}.lisp", true),
                null,
                true)
        {
            _mqProgram = this.LifetimeScope.Resolve<MqProgramBase>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var types = _mqProgram.PublishedMessageTypes;

            foreach (var type in types)
            {
                this.Output.WriteLine(type.FullName);
            }
        }
    }
}
