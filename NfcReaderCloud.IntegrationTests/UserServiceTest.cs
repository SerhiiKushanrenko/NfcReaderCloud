using BLL.Services;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Moq;

namespace NfcReaderCloud.IntegrationTests
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _UserRepositoryMock;
        private IQueryable<User> Users = new List<User>()
        {
            new(){Id = 1 ,Name = "Andrew",UsbDeviceId = "123"},
        }.AsQueryable();

        public UserServiceTest()
        {
            _UserRepositoryMock = new();
            _UserRepositoryMock.Setup(b => b.GetAll()).Returns(Users);
        }

        [Fact]
        public async Task GetUsersCount_SendRequest_ShouldReturnActualOrdersCount()
        {
            // arrange 
            var service = _UserRepositoryMock.Object;
            var userService = new UserService(service);

            //act
            var result = await userService.GetAllUsers();

            //assert
            Assert.Equal(1, result);

        }
    }
}
