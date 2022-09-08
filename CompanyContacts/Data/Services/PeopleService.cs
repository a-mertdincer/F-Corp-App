using CompanyContacts.Data.Base;
using CompanyContacts.Data.Enums;
using CompanyContacts.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CompanyContacts.Data.Services
{
    public class PeopleService : EntityBaseRepository<Person>, IPeopleService
    {
        private readonly AppDbContext _context;
        public PeopleService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewContactAsync(NewPersonVM data)
        {
            var newContact = new Person()
            {
                Name = data.Name,
                LastName = data.LastName,
                JobTitle = data.JobTitle,
                BusinessPhone = data.BusinessPhone,
                PersonalPhone = data.PersonalPhone,
                EmailAddress = data.EmailAddress,
                Address = data.Address,
                BloodType = data.BloodType,
                EmergencyPhone = data.EmergencyPhone,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
            };
            await _context.People.AddAsync(newContact);
            await _context.SaveChangesAsync();


        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            var personDetails = await _context.People
                .FirstOrDefaultAsync(n => n.Id == id);

            return personDetails;
        }

        public async Task UpdateContactAsync(NewPersonVM data)
        {
            var dbPerson = await _context.People.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbPerson != null)
            {

                dbPerson.Name = data.Name;
                dbPerson.LastName = data.LastName;
                dbPerson.JobTitle = data.JobTitle;
                dbPerson.BusinessPhone = data.BusinessPhone;
                dbPerson.PersonalPhone = data.PersonalPhone;
                dbPerson.EmailAddress = data.EmailAddress;
                dbPerson.Address = data.Address;
                dbPerson.BloodType = data.BloodType;
                dbPerson.EmergencyPhone = data.EmergencyPhone;
                dbPerson.ImageURL = data.ImageURL;
                dbPerson.StartDate = data.StartDate;
            };
            await _context.SaveChangesAsync();
        }


    }
}

