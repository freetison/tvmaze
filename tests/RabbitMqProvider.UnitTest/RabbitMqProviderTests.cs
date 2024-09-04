using Moq;

using Newtonsoft.Json;

using RabbitMQ.Client;

using TvMaze.RabbitMqProvider;

namespace RabbitMqProvider.UnitTest
{
    public class RabbitMqProviderTests
    {
        private readonly Mock<IConnection> _mockConnection;
        private readonly Mock<IModel> _mockChannel;
        private readonly Mock<IConnectionFactory> _mockConnectionFactory;
        private readonly RabbitMqClientProvider _provider;
        private readonly string _queueName = "testQueue";
        private readonly TestMessage _messageToSend;
        private readonly byte[] _messageBody;

        public RabbitMqProviderTests()
        {
            _mockConnection = new Mock<IConnection>();
            _mockChannel = new Mock<IModel>();
            _mockConnectionFactory = new Mock<IConnectionFactory>();

            _mockConnectionFactory.Setup(f => f.CreateConnection()).Returns(_mockConnection.Object);
            _mockConnection.Setup(c => c.CreateModel()).Returns(_mockChannel.Object);

            // _provider = new RabbitMqClientProvider(_mockConnectionFactory.Object);
            // _messageToSend = new TestMessage { Text = "Test Message" };
            // _messageBody = Encoding.UTF8.GetBytes(_messageToSend.ToJson());
        }

        [Fact]
        public void RabbitMqProviderConnectConnectsCorrectly()
        {
            // Assert
            _mockConnectionFactory.Verify(conn => conn.CreateConnection(), Times.Once);
        }

        // [Fact]
        // public void SendMessageShouldCallBasicPublish()
        // {
        //    // Act
        //    _provider.SendMessage(_queueName, _messageToSend);

        // // Assert
        //    _mockChannel.Verify(
        //        c => c.BasicPublish(
        //            string.Empty,
        //            _queueName,
        //            It.IsAny<IBasicProperties>(),
        //            It.Is<ReadOnlyMemory<byte>>(body => Encoding.UTF8.GetString(body.ToArray()) == _messageToSend.ToJson())),
        //        Times.Once);
        // }
    }

    public class TestMessage
    {
        public string? Text { get; set; }

        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}