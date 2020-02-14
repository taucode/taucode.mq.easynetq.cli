using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using TauCode.Cli;
using TauCode.Cli.Exceptions;
using TauCode.Mq.Abstractions;
using TauCode.Mq.Autofac;
using TauCode.Mq.EasyNetQ.Cli.AddIns;
using TauCode.Mq.EasyNetQ.Cli.AddIns.PublisherWorkers;
using TauCode.Mq.EasyNetQ.Cli.AddIns.SubscriberWorkers;
using TauCode.Mq.EasyNetQ.Cli.Exceptions;

namespace TauCode.Mq.EasyNetQ.Cli
{
    public class MqProgramBase
    {
        public MqProgramBase(
            Type[] publishedMessageTypes,
            Type[] availableMessageHandlerTypes,
            string connectionString)
        {
            #region check published message types

            if (publishedMessageTypes == null)
            {
                throw new ArgumentNullException(nameof(publishedMessageTypes));
            }

            if (publishedMessageTypes.Any(x => x == null))
            {
                throw new ArgumentException($"'{publishedMessageTypes}' cannot contain nulls.");
            }

            var badMessageType = publishedMessageTypes.FirstOrDefault(x => !x.IsAssignableTo<IMessage>());
            if (badMessageType != null)
            {
                throw new ArgumentException($"'{badMessageType.FullName}' is not derived from '{typeof(IMessage).FullName}'.");
            }

            #endregion

            #region check available message handler types

            if (availableMessageHandlerTypes == null)
            {
                throw new ArgumentNullException(nameof(availableMessageHandlerTypes));
            }

            if (availableMessageHandlerTypes.Any(x => x == null))
            {
                throw new ArgumentException($"'{availableMessageHandlerTypes}' cannot contain nulls.");
            }

            foreach (var messageHandlerType in availableMessageHandlerTypes)
            {
                if (!messageHandlerType.IsAssignableTo<IMessageHandler>())
                {
                    throw new ArgumentException($"'{nameof(messageHandlerType)}' is not derived from 'IMessageHandler'");
                }
            }

            #endregion

            this.PublishedMessageTypes = publishedMessageTypes.Distinct().ToList();
            this.AvailableMessageHandlerTypes = availableMessageHandlerTypes.Distinct().ToList();

            this.ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        protected IContainer Container { get; private set; }
        protected string ConnectionString { get; private set; }

        public IReadOnlyList<Type> PublishedMessageTypes { get; }
        public IReadOnlyList<Type> AvailableMessageHandlerTypes { get; }

        public void Init()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterInstance(this)
                .As<MqProgramBase>()
                .SingleInstance();

            builder
                .RegisterType<EasyNetQMessagePublisher>()
                .As<IMessagePublisher>()
                .WithProperty(nameof(EasyNetQMessagePublisher.ConnectionString), this.ConnectionString)
                .SingleInstance();

            builder
                .RegisterType<EasyNetQMessageSubscriber>()
                .As<IMessageSubscriber>()
                .WithProperty(nameof(EasyNetQMessageSubscriber.ConnectionString), this.ConnectionString)
                .SingleInstance();

            builder
                .RegisterType<AutofacMessageHandlerContextFactory>()
                .As<IMessageHandlerContextFactory>()
                .SingleInstance();

            var cliTypes = new[]
            {
                typeof(MqHost),

                typeof(PublisherAddIn),
                typeof(SubscriberAddIn),

                typeof(MessagePublisherWorker),
                typeof(StartPublisherWorker),
                typeof(StatusPublisherWorker),
                typeof(StopPublisherWorker),
                typeof(MessageTypePublisherWorker),
                typeof(MessageTypesPublisherWorker),

                typeof(GetSubscriptionsSubscriberWorker),
                typeof(HandlerTypesSubscriberWorker),
                typeof(HandlerTypeSubscriberWorker),
                typeof(StartSubscriberWorker),
                typeof(StatusSubscriberWorker),
                typeof(StopSubscriberWorker),
                typeof(SubscribeHandlerSubscriberWorker),
                typeof(UnsubscribeAllSubscriberWorker),
            };

            foreach (var cliType in cliTypes)
            {
                builder
                    .RegisterType(cliType)
                    .AsSelf()
                    .SingleInstance();
            }

            foreach (var messageHandlerType in this.AvailableMessageHandlerTypes)
            {
                builder
                    .RegisterType(messageHandlerType)
                    .AsSelf()
                    .InstancePerLifetimeScope();
            }

            this.Container = builder.Build();
        }

        public virtual void Run()
        {
            var publisher = this.Container.Resolve<IMessagePublisher>();
            var subscriber = this.Container.Resolve<IMessageSubscriber>();

            publisher.Start();
            
            var host = this.Container.Resolve<MqHost>();
            host.Output = Console.Out;


            host.AddCustomHandler(
                () => throw new ExitException(),
                "exit");

            host.AddCustomHandler(
                Console.Clear,
                "cls");

            while (true)
            {
                try
                {
                    Console.Write(" : ");
                    var line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    var command = host.ParseLine(line);
                    host.DispatchCommand(command);
                }
                catch (CliCustomHandlerException)
                {
                    // ignore
                }
                catch (ExitException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // todo: virtual method 'Output exception'
                }
            }

            try
            {
                subscriber.Dispose();
            }
            catch
            {
                // dismiss
            }

            try
            {
                publisher.Dispose();
            }
            catch
            {
                // dismiss
            }
        }
    }
}
