using Autofac;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers
{
    public class TypesPublisherWorker : AutofacCliWorkerBase
    {
        private readonly MqProgramBase _mqProgram;

        public TypesPublisherWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(TypesPublisherWorker)}.lisp", true),
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
