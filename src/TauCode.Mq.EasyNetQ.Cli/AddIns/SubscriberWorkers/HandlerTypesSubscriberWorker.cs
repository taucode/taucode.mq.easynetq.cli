using Autofac;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class HandlerTypesSubscriberWorker : SubscriberWorkerBase
    {
        private readonly MqProgramBase _mqProgram;

        public HandlerTypesSubscriberWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(HandlerTypesSubscriberWorker)}.lisp", true),
                null,
                true)
        {
            _mqProgram = this.LifetimeScope.Resolve<MqProgramBase>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var types = _mqProgram.AvailableMessageHandlerTypes;

            foreach (var type in types)
            {
                this.Output.WriteLine(type.FullName);
            }
        }
    }
}
