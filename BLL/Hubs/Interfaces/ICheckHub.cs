using BLL.DTOs;

namespace BLL.Hubs.Interfaces
{
    public interface ICheckHub
    {
        Task Check(UserAuthDTO userDto);
        Task SendMessageAsync(string message);
        Task<bool> CheckHubAsync(bool flag);
    }
}
