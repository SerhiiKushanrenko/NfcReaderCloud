using BLL.DTOs;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class AddGuidService : IAddGuidService
    {
        private Dictionary<Guid, string> _guidDictionary;

        public AddGuidService(Dictionary<Guid, string> guidDictionary)
        {
            _guidDictionary = guidDictionary;
        }
        public Task AddGuidToList(WebPageDTO pageDto)
        {
            _guidDictionary.Add(pageDto.Id, pageDto.ConnectionId);
            return Task.CompletedTask;
        }
    }
}
