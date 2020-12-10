using Autofac;
using System;
using System.Collections.Generic;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherExecutors
{
    public class MessagePublisherExecutor : PublisherExecutorBase
    {
        private readonly MqProgramBase _mqProgram;

        public MessagePublisherExecutor(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(MessagePublisherExecutor)}.lisp", true),
                null,
                true)
        {
            _mqProgram = this.LifetimeScope.Resolve<MqProgramBase>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            throw new NotImplementedException();
            //var summary = (new CliCommandSummaryBuilder()).Build(this.Descriptor, entries);
            //var typeName = summary.Arguments["type-name"].Single();
            //var json = summary.Arguments.GetOrDefault("json")?.SingleOrDefault();
            //var isClipboard = summary.Options.Contains("clipboard");
            //var fileName = summary.Keys.GetOrDefault("file")?.SingleOrDefault();
            //var topic = summary.Keys.GetOrDefault("topic")?.SingleOrDefault();

            //if (json == null)
            //{
            //    if (isClipboard)
            //    {
            //        var clipboard = new Clipboard();
            //        json = clipboard.GetText(); // todo: not sure if this will work.
            //    }
            //    else
            //    {
            //        json = File.ReadAllText(fileName, Encoding.UTF8);
            //    }
            //}

            //var types = _mqProgram.PublishedMessageTypes;
            //var matchingTypes = types
            //    .Where(x => x.FullName.IndexOf(typeName, StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    .ToList();

            //if (matchingTypes.Count != 1)
            //{
            //    throw new Exception($"Failed to find exactly one type matching substring '{typeName}'.");
            //}

            //var type = matchingTypes.Single();


            //var message = (IMessage)JsonConvert.DeserializeObject(json, type);

            //if (topic == null)
            //{
            //    this.MessagePublisher.Publish(message);
            //}
            //else
            //{
            //    this.MessagePublisher.Publish(message, topic);
            //}
        }
    }
}
