using ContactApi.Model;
using ContactApi.Repository;

namespace ContactApi.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<int> AddContact(Contact contact)
        {
            return await _contactRepository.AddContact(contact);
        }

        public async Task<int> DeleteContact(int contactId)
        {
            return await (_contactRepository.DeleteContact(contactId));
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _contactRepository.GetContactById(id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactRepository.GetContacts();
        }

        public async Task<int> UpdateContact(Contact contact)
        {
            return await _contactRepository.UpdateContact(contact);
        }
    }
}
