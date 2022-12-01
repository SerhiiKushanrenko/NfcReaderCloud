using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface IAddGuidService
    {
        Task AddGuidToList(WebDataDTO pageDto);
    }
}
