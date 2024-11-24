using System.Collections.Generic;
using MongoDB.Driver;
using MyApp.Application.DTOs;

namespace MyApp.Infrastructure.Data.NoSql
{
    public class MongoClientProjection
    {
        private readonly MongoDbContext _context;

        public MongoClientProjection(MongoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ClientDto> GetClients()
        {
            var collection = _context.GetCollection<ClientDto>("Clients");
            return collection.Find(_ => true).ToList();
        }
    }
}
