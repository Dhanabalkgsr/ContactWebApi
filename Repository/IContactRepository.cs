using ContactApi.Model;

namespace ContactApi.Repository
{
    public interface IContactRepository
    {

        Task<int> AddContact(Contact contact);
        Task<int> UpdateContact(Contact contact);
        Task<int> DeleteContact(int contactId);
        Task<Contact> GetContactById(int id);
        Task<IEnumerable<Contact>> GetContacts();
    }
}
