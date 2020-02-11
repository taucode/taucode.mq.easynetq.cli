using Autofac;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli.CommandSummary;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.Abstractions;
using TauCode.Mq.EasyNetQ.Cli.Lab.Di;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers
{
    public class MessagePublisherWorker : AutofacCliWorkerBase
    {
        private readonly MqProgramBase _mqProgram;
        private readonly IMessagePublisher _messagePublisher;

        public MessagePublisherWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(MessagePublisherWorker)}.lisp", true),
                null,
                true)
        {
            _mqProgram = this.LifetimeScope.Resolve<MqProgramBase>();
            _messagePublisher = this.LifetimeScope.Resolve<IMessagePublisher>();
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

            var clipboard = summary.Options.Contains("clipboard");
            if (!clipboard)
            {
                throw new NotImplementedException();
            }

            var json = TextCopy.Clipboard.GetText();
            var message = (IMessage)JsonConvert.DeserializeObject(json, type);

            _messagePublisher.Publish(message);
        }
    }
}
