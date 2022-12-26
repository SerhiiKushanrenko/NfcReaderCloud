using AutoFixture;
using BLL.Hubs;
using BLL.Hubs.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace NfcReaderCloud.UnitTests
{
    public class AuthServiceTest
    {
        public Dictionary<Guid, string> _guidDictionary = new Dictionary<Guid, string>()
        {
            { Guid.NewGuid(), "Sam" }

        };

        [Fact]
        [Trait("CheckHub", "SendMessageAsync")]

        public async Task CheckUseMethod_ShouldGetTrue_WhenCallMethod()
        {
            // arrange
            var messageHub = new Mock<IHubContext<CheckHub, ICheckHub>>();
            var mockClientProxy = new Mock<ICheckHub>();
            var mockClients = new Mock<IHubClients<ICheckHub>>();
            mockClients.Setup(clients => clients.User(It.IsAny<string>())).Returns(mockClientProxy.Object);
            messageHub.Setup(x => x.Clients).Returns(() => mockClients.Object);

            var data = new Fixture().Create<string>();

            // act
            await messageHub.Object.Clients.User("identifier").SendMessageAsync(data);

            // assert
            mockClientProxy.Verify(x => x.SendMessageAsync(It.IsAny<string>()), Times.Once);
        }
    }
}