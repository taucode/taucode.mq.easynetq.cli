﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli.CommandSummary;
using TauCode.Cli.Data;
using TauCode.Extensions;

namespace TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers
{
    public class SubscribeHandlerSubscriberWorker : SubscriberWorkerBase
    {
        private readonly MqProgramBase _mqProgram;

        public SubscribeHandlerSubscriberWorker(ILifetimeScope lifetimeScope)
            : base(
                lifetimeScope,
                typeof(MqHost).Assembly.GetResourceText($".{nameof(SubscribeHandlerSubscriberWorker)}.lisp", true),
                null,
                true)
        {
            _mqProgram = this.LifetimeScope.Resolve<MqProgramBase>();
        }

        public override void Process(IList<CliCommandEntry> entries)
        {
            var summary = (new CliCommandSummaryBuilder()).Build(this.Descriptor, entries);
            var typeName = summary.Arguments["type-name"].Single();
            var topic = summary.Keys.GetOrDefault("topic")?.SingleOrDefault();

            var types = _mqProgram.AvailableMessageHandlerTypes;
            var matchingTypes = types
                .Where(x => x.FullName.IndexOf(typeName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .ToList();

            if (matchingTypes.Count != 1)
            {
                throw new Exception($"Failed to find exactly one type matching substring '{typeName}'.");
            }

            var type = matchingTypes.Single();

            if (topic == null)
            {
                this.MessageSubscriber.Subscribe(type);
            }
            else
            {
                this.MessageSubscriber.Subscribe(type, topic);
            }
        }
    }
}