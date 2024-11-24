using System.Collections.Generic;
using MyApp.Application.DTOs;

namespace MyApp.Application.Queries
{
    public class GetClientsQuery
    {
        public IEnumerable<ClientDto> Execute()
        {
            // Aqui é onde você chamaria a projeção do MongoDB
            return new List<ClientDto>(); // Placeholder
        }
    }
}
