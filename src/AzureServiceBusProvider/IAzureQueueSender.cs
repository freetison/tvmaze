namespace AzureServiceBusProvider
{
    public interface IAzureQueueSender
    {
        ValueTask PublishAsync<T>(T item, Dictionary<string, object> properties);
    }
}