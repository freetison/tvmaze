namespace BrokerProviderContract
{
    public interface IMessageBrokerProvider
    {
        ValueTask PublishAsync<T>(T message);

        T? Receive<T>();
    }
}