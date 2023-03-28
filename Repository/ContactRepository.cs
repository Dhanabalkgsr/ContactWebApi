using ContactApi.Context;
using ContactApi.Model;
using Dapper;

namespace ContactApi.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;
        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddContact(Contact contact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", contact.FirstName);
            parameters.Add("LastName", contact.LastName);
            parameters.Add("Email", contact.Email);
            parameters.Add("PhoneNumber", contact.PhoneNumber);
            parameters.Add("Address", contact.Address);
            parameters.Add("City", contact.City);
            parameters.Add("State", contact.State);
            parameters.Add("Country", contact.Country);
            parameters.Add("PostalCode", contact.PostalCode);

            var query = $"INSERT INTO Contacts([FirstName],[LastName],[Email],[PhoneNumber]" +
                $",[Address],[City],[State],[Country],[PostalCode])VALUES" +
                $"(@FirstName,@LastName,@Email,@PhoneNumber,@Address ,@City" +
                $" ,@State,@Country ,@PostalCode)";

            using (var connection = _context.CreateConnection())
                return (await connection.QueryAsync<int>(query, parameters)).FirstOrDefault();
        }

        public async Task<int> DeleteContact(int contactId)
        {
            var sql = $" DELETE FROM Contacts WHERE ContactId = @contactId";
            var parameters = new DynamicParameters();
            parameters.Add("contactId", contactId);
            using (var connection = _context.CreateConnection())
                return (await connection.QueryAsync<int>(sql, parameters)).FirstOrDefault();
        }

        public async Task<Contact> GetContactById(int id)
        {
            var sql = $" SELECT * FROM Contacts WHERE ContactId = @contactId";
            var parameters = new DynamicParameters();
            parameters.Add("contactId", id);
            using (var connection = _context.CreateConnection())
                return (await connection.QueryAsync<Contact>(sql, parameters)).First();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var sql = $" SELECT *  FROM Contacts ";
            using (var connection = _context.CreateConnection())
                return await connection.QueryAsync<Contact>(sql);
        }



        public async Task<int> UpdateContact(Contact contact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ContactId", contact.ContactId);

            parameters.Add("FirstName", contact.FirstName);
            parameters.Add("LastName", contact.LastName);
            parameters.Add("Email", contact.Email);
            parameters.Add("PhoneNumber", contact.PhoneNumber);
            parameters.Add("Address", contact.Address);
            parameters.Add("City", contact.City);
            parameters.Add("State", contact.State);
            parameters.Add("Country", contact.Country);
            parameters.Add("PostalCode", contact.PostalCode);

            var query = $" UPDATE Contacts SET [FirstName] = @FirstName, [LastName] = @LastName,[Email] = @Email" +
                $",[PhoneNumber] = @PhoneNumber,[Address] = @Address,[City] = @City,[State] = @State , " +
                $"[Country] = @Country ,[PostalCode] = @PostalCode WHERE ContactId = @ContactId";

            using (var connection = _context.CreateConnection())
                return (await connection.QueryAsync<int>(query, parameters)).FirstOrDefault();
        }
    }
}
