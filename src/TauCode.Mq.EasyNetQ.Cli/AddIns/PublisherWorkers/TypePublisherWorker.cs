using Autofac;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli.CommandSummary;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers
{
    public class TypePublisherWorker : AutofacCliWorkerBase
    {
        private readonly MqProgramBase _mqProgram;

        public TypePublisherWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(TypePublisherWorker)}.lisp", true),
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
