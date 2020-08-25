using System.Collections.Generic;
using Autofac;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberExecutors
{
    public class HandlerTypesSubscriberExecutor : SubscriberExecutorBase
    {
        private readonly MqProgramBase _mqProgram;

        public HandlerTypesSubscriberExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(HandlerTypesSubscriberExecutor)}.lisp", true),
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
