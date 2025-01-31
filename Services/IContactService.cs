using System.Collections.Generic;
using ContactM.Models;

namespace ContactM.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync(int pageNumber, int pageSize);
        Task<Contact> GetByIdAsync(int id);
        Task<Contact> AddAsync(Contact newContact);
       /* Task<Contact> UpdateAsync(int id, Contact updatedContact);
        Task<bool> DeleteAsync(int id);*/
    }
}
