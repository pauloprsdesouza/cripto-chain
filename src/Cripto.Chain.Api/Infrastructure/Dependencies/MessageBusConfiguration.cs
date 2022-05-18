using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cripto.Chain.Api.Infrastructure.Dependencies
{
    public static class MessageBusConfiguration
    {
        public static void MessageBusConfigure(this IServiceCollection service, IConfiguration configuration)
        {
            var connection = configuration["MessageBusHost"];

            service.AddSingleton<IBus>(RabbitHutch.CreateBus(connection));
        }
    }
}
