using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Newtonsoft.Json;
using TauCode.Cli.CommandSummary;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherExecutors
{
    public class MessageTypePublisherExecutor : PublisherExecutorBase
    {
        private readonly MqProgramBase _mqProgram;

        public MessageTypePublisherExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(MessageTypePublisherExecutor)}.lisp", true),
                null,
                true)
        {
            _mqProgram = this.LifetimeScope.Resolve<MqProgramBase>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var summary = (new CliCommandSummaryBuilder()).Build(this.Descriptor, entries);
            var typeName = summary.Arguments["type-name"].Single();

            var types = _mqProgram.PublishedMessageTypes;
            var matchingTypes = types
                .Where(x => x.FullName.IndexOf(typeName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .ToList();

            if (matchingTypes.Count != 1)
            {
                throw new Exception($"Failed to find exactly one type matching substring '{typeName}'.");
            }

            var type = matchingTypes.Single();
            var sample = Activator.CreateInstance(type);
            var json = JsonConvert.SerializeObject(sample, Formatting.Indented);

            this.Output.WriteLine(json);
        }
    }
}
