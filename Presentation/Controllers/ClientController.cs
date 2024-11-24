using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.DTOs;

namespace MyApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _clientService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Add(ClientDto clientDto)
        {
            await _clientService.AddAsync(clientDto);
            return CreatedAtAction(nameof(GetAll), clientDto);
        }
    }
}
