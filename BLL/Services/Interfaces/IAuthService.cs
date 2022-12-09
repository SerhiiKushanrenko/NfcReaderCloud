using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface IAuthService
    {
        public Task Check(UserAuthDTO userDto);
    }
}
