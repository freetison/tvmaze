namespace AzureServiceBusProvider
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Threading.Tasks;
    using BrokerProviderContract;
    using Microsoft.Azure.ServiceBus;
    using Newtonsoft.Json;

    public class AzureServiceBusQueueProvider : IMessageBrokerProvider, IAzureQueueSender
    {
        private readonly IQueueClient _queueClient;

        public AzureServiceBusQueueProvider([NotNull] IQueueClient queueClient)
        {
            if (queueClient == null)
            {
                throw new ArgumentNullException(nameof(queueClient), "QueueClient cannot be null.");
            }

            _queueClient = queueClient;
        }

        public async ValueTask PublishAsync<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var msg = new Message(Encoding.UTF8.GetBytes(json));

            await _queueClient.SendAsync(msg);
        }

        public async ValueTask PublishAsync<T>(T message, Dictionary<string, object> properties)
        {
            var json = JsonConvert.SerializeObject(message);
            var msg = new Message(Encoding.UTF8.GetBytes(json));

            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    msg.UserProperties.Add(prop.Key, prop.Value);
                }
            }

            await _queueClient.SendAsync(msg);
        }

        public T? Receive<T>()
        {
            Console.WriteLine("Receiving message from Azure Service Bus...");
            return default(T);
        }
    }
}