using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface ICheckDataService
    {
        public Task Check(UserAuthDTO userDto);
    }
}
