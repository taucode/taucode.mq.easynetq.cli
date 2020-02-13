﻿using Autofac;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TauCode.Cli.CommandSummary;
using TauCode.Cli.Data;
using TauCode.Extensions;
using TauCode.Mq.Abstractions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers
{
    public class MessagePublisherWorker : PublisherWorkerBase
    {
        private readonly MqProgramBase _mqProgram;

        public MessagePublisherWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(MessagePublisherWorker)}.lisp", true),
                null,
                true)
        {
            _mqProgram = this.LifetimeScope.Resolve<MqProgramBase>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var summary = (new CliCommandSummaryBuilder()).Build(this.Descriptor, entries);
            var typeName = summary.Arguments["type-name"].Single();
            var json = summary.Arguments.GetOrDefault("json")?.SingleOrDefault();
            var isClipboard = summary.Options.Contains("clipboard");
            var fileName = summary.Keys.GetOrDefault("file")?.SingleOrDefault();
            var topic = summary.Keys.GetOrDefault("topic")?.SingleOrDefault();

            if (json == null)
            {
                if (isClipboard)
                {
                    json = TextCopy.Clipboard.GetText();
                }
                else
                {
                    json = File.ReadAllText(fileName, Encoding.UTF8);
                }
            }

            var types = _mqProgram.PublishedMessageTypes;
            var matchingTypes = types
                .Where(x => x.FullName.IndexOf(typeName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .ToList();

            if (matchingTypes.Count != 1)
            {
                throw new Exception($"Failed to find exactly one type matching substring '{typeName}'.");
            }

            var type = matchingTypes.Single();

            
            var message = (IMessage)JsonConvert.DeserializeObject(json, type);

            if (topic == null)
            {
                this.MessagePublisher.Publish(message);
            }
            else
            {
                this.MessagePublisher.Publish(message, topic);
            }
        }
    }
}
