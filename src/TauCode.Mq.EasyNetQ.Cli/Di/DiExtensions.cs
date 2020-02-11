using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TauCode.Mq.EasyNetQ.Cli.Lab.Di
{
    public static class DiExtensions
    {
        public static IList<Type> GetTypesDerivedFrom<T>(this ILifetimeScope lifetimeScope)
        {
            var types = new List<Type>();

            foreach (var registration in lifetimeScope.ComponentRegistry.Registrations)
            {
                var services = registration.Services.ToList();
                if (services.Count != 1)
                {
                    // looks like not our case.
                    continue;
                }

                var service = services.Single();
                if (service is TypedService typedService)
                {
                    if (typedService.ServiceType.IsAssignableTo<T>())
                    {
                        types.Add(typedService.ServiceType);
                    }
                }
            }

            return types;
        }
    }
}
