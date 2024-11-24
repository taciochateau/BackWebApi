using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Domain.Interfaces;

namespace MyApp.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients.Select(c => new ClientDto
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Size = c.Size.ToString()
            });
        }

        public async Task AddAsync(ClientDto clientDto)
        {
            var client = new Client
            {
                CompanyName = clientDto.CompanyName,
                Size = Enum.Parse<CompanySize>(clientDto.Size)
            };
            await _clientRepository.AddAsync(client);
        }

        public async Task UpdateAsync(ClientDto clientDto)
        {
            var client = new Client
            {
                Id = clientDto.Id,
                CompanyName = clientDto.CompanyName,
                Size = Enum.Parse<CompanySize>(clientDto.Size)
            };
            await _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }
    }
}
