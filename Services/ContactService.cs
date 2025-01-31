using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ContactM.Models;

namespace ContactM.Services
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        public ContactService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            _contactCollection = database.GetCollection<Contact>(configuration["MongoDbSettings:CollectionName"]);
        }

        
        public async Task<List<Contact>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _contactCollection.Find(_ => true).Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _contactCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
       

        public async Task<Contact> AddAsync(Contact newcontact)
        {
            await _contactCollection.InsertOneAsync(newcontact);
            return newcontact;
        }

/*
        public async Task<Pokemon> UpdateAsync(int id, Pokemon updatedPokemon)
        {
            await _pokemonCollection.ReplaceOneAsync(p => p.Id == id, updatedPokemon);
            return updatedPokemon;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _pokemonCollection.DeleteOneAsync(p => p.Id == id);
            return result.DeletedCount > 0;
        }*/
    }
}
