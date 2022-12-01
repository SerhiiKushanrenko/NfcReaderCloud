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
        public Task AddGuidToList(WebDataDTO pageDto)
        {
            _guidDictionary.Add(Guid.Parse(pageDto.Id), pageDto.ConnectionId);
            return Task.CompletedTask;
        }
    }
}
