using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Application.DTOs;

namespace MyApp.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task AddAsync(ClientDto clientDto);
        Task UpdateAsync(ClientDto clientDto);
        Task DeleteAsync(int id);
    }
}
