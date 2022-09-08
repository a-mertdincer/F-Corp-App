using CompanyContacts.Data.Base;
using CompanyContacts.Models;
using System.Threading.Tasks;

namespace CompanyContacts.Data.Services
{
    public interface IPeopleService:IEntityBaseRepository<Person>
    {
        Task<Person> GetPersonByIdAsync(int id);
        Task AddNewContactAsync(NewPersonVM data);
        Task UpdateContactAsync(NewPersonVM data);

    }
}
