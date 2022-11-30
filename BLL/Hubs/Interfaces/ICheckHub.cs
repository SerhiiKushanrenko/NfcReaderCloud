namespace BLL.Hubs.Interfaces
{
    public interface ICheckHub
    {
        Task<bool> CheckHubAsync(bool flag);
    }
}
