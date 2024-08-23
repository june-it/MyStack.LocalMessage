using Microsoft.Extensions.LocalMessage;
using Microsoft.Extensions.LocalMessage.Subscriptions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加本地消息总线
        /// </summary>
        /// <param name="services">服务集合</param> 
        /// <param name="assemblies">注册事件订阅的程序集</param>
        /// <returns>返回服务集合</returns>
        public static IServiceCollection AddLocalMessage(this IServiceCollection services, params Assembly[] assemblies)
        {

            services.AddTransient<ILocalMessageBus, DefaultLocalEventBus>();

            List<SubscriptionInfo> subscriptions = new List<SubscriptionInfo>();
            var eventHandlerTypes = assemblies.SelectMany(x => x.GetTypes().Where(x => !x.IsAbstract && x.IsPublic && x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(ILocalEventHandler<>))));
            if (eventHandlerTypes.Any())
            {
                foreach (var eventHandlerType in eventHandlerTypes)
                {
                    var handlerInterfaces = eventHandlerType.GetInterfaces()
                        .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ILocalEventHandler<>));
                    foreach (var handlerInterface in handlerInterfaces)
                    {
                        if (handlerInterface.GetGenericArguments()[0].IsGenericType && handlerInterface.GetGenericArguments()[0].GetGenericTypeDefinition() == typeof(LocalEventWrapper<>))
                        {
                            services.AddTransient(typeof(ILocalEventHandler<>).MakeGenericType(handlerInterface.GetGenericArguments()), eventHandlerType);
                            subscriptions.Add(new SubscriptionInfo(handlerInterface.GetGenericArguments()[0].GetGenericArguments()[0], typeof(ILocalEventHandler<>)));
                        }
                        else
                        {
                            services.AddTransient(typeof(ILocalEventHandler<>).MakeGenericType(handlerInterface.GetGenericArguments()), eventHandlerType);
                            subscriptions.Add(new SubscriptionInfo(handlerInterface.GetGenericArguments()[0], typeof(ILocalEventHandler<>)));
                        }
                    }
                }
            }

            var requestHandlerTypes = assemblies.SelectMany(x => x.GetTypes().Where(x => !x.IsAbstract && x.IsPublic && x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))));
            if (requestHandlerTypes.Any())
            {
                foreach (var requestHandlerType in requestHandlerTypes)
                {
                    var handlerInterfaces = requestHandlerType.GetInterfaces()
                        .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));
                    foreach (var handlerInterface in handlerInterfaces)
                    {
                        services.AddTransient(typeof(IRequestHandler<,>).MakeGenericType(handlerInterface.GetGenericArguments()), requestHandlerType);
                        subscriptions.Add(new SubscriptionInfo(handlerInterface.GetGenericArguments()[0], typeof(IRequestHandler<,>), handlerInterface.GetGenericArguments()[1]));
                    }
                }
            }

            services.AddSingleton<ISubscriptionRegistrar, DefaultSubscriptionManager>();
            services.AddSingleton<ISubscriptionManager>(factory =>
            {
                var subscriptionRegistrar = factory.GetRequiredService<ISubscriptionRegistrar>();
                subscriptionRegistrar.Register(subscriptions);
                return (DefaultSubscriptionManager)subscriptionRegistrar;
            });


            return services;
        }
    }
}
