using Autofac;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers
{
    public class MessageTypesPublisherWorker : PublisherWorkerBase
    {
        private readonly MqProgramBase _mqProgram;

        public MessageTypesPublisherWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(MessageTypesPublisherWorker)}.lisp", true),
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
