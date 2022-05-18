using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Cripto.Chain.Api.Infrastructure.MessageBus
{
    public static class MessageBroker
    {
        private static IExchange _exchangeName;
        private static IQueue _queueName;
        private const string _routingKey = "default";

        public static IBus WithExchangeName(this IBus bus, string exchangeName)
        {
            _exchangeName = bus.Advanced.ExchangeDeclare(exchangeName, ExchangeType.Topic);
            return bus;
        }

        public static IBus WithQueueName(this IBus bus, string queueNme)
        {
            _queueName = bus.Advanced.QueueDeclare(queueNme);
            return bus;
        }

        public static IBus Bind(this IBus bus)
        {
            bus.Advanced.Bind(_exchangeName, _queueName, _routingKey);
            return bus;
        }

        public static async Task Publish(this IBus bus, IMessage mesage)
        {
            await bus.Advanced.PublishAsync(_exchangeName, _routingKey, false, mesage);
        }

        public static async Task Subscribe<T>(this IBus bus, Func<T, Task> processMessage) where T : class
        {
            await bus.PubSub.SubscribeAsync<T>(string.Empty, processMessage);
        }
    }
}
