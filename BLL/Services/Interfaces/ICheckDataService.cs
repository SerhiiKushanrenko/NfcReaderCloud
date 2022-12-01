using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface ICheckDataService
    {
        public void Check(UserAuthDTO userDto);
    }
}
