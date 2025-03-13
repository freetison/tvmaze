namespace TvMaze.AzureServiceBusProviderTest
{
    using System.Reflection;
    using System.Text;
    using AzureServiceBusProvider;
    using Microsoft.Azure.ServiceBus;
    using Moq;
    using Newtonsoft.Json;
    using Shouldly;

    public class AzureServiceBusQueueProviderTest
    {
        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_QueueClient_Is_Null()
        {
            // Arrange

            // Act & Assert
            var constructor = typeof(AzureServiceBusQueueProvider).GetConstructor(new[] { typeof(IQueueClient) });

            var exception = Should.Throw<TargetInvocationException>(() =>
                constructor?.Invoke([null])
            );

            exception.InnerException.ShouldBeOfType<ArgumentNullException>();
            var argNullException = (ArgumentNullException)exception.InnerException;
            argNullException.ParamName.ShouldBe("queueClient");
            argNullException.Message.ShouldContain("QueueClient cannot be null.");
        }

        [Fact]
        public async Task PublishAsync_Should_SendMessageToQueue()
        {
            // Arrange
            var mockQueueClient = new Mock<IQueueClient>();
            var provider = new AzureServiceBusQueueProvider(mockQueueClient.Object);
            var message = new { Id = 1, Name = "Test" };

            // Act
            await provider.PublishAsync(message);

            // Assert
            mockQueueClient.Verify(x => x.SendAsync(It.IsAny<Message>()), Times.Once);

            mockQueueClient.Verify(x => x.SendAsync(It.Is<Message>(msg => Encoding.UTF8.GetString(msg.Body) == JsonConvert.SerializeObject(message))), Times.Once);
        }

        [Fact]
        public async Task SendAsync_Should_SendMessageWithProperties()
        {
            // Arrange
            var mockQueueClient = new Mock<IQueueClient>();
            var provider = new AzureServiceBusQueueProvider(mockQueueClient.Object);
            var message = new { Id = 1, Name = "Test" };
            var properties = new Dictionary<string, object>
        {
            { "Priority", "High" },
            { "RetryCount", 3 },
        };

            // Act
            await provider.PublishAsync(message, properties);

            // Assert
            mockQueueClient.Verify(
                x => x.SendAsync(It.Is<Message>(msg =>
                Encoding.UTF8.GetString(msg.Body) == JsonConvert.SerializeObject(message) &&
                msg.UserProperties["Priority"].ToString() == "High" &&
                (int)msg.UserProperties["RetryCount"] == 3
            )), Times.Once);
        }

        [Fact]
        public void Receive_Should_ReturnDefault()
        {
            // Arrange
            var mockQueueClient = new Mock<IQueueClient>();
            var provider = new AzureServiceBusQueueProvider(mockQueueClient.Object);

            // Act
            var result = provider.Receive<string>();

            // Assert
            result.ShouldBe(null);
        }
    }
}