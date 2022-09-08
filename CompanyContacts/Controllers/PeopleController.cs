using CompanyContacts.Data;
using CompanyContacts.Data.Services;
using CompanyContacts.Data.Static;
using CompanyContacts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyContacts.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PeopleController : Controller
    {
        private readonly IPeopleService _service;

        public PeopleController(IPeopleService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPeople = await _service.GetAllAsync();
            return View(allPeople);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allPeople = await _service.GetAllAsync();

            if(!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allPeople.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || 
                //n.LastName.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResult = allPeople.Where(n => string.Equals(n.Name, searchString,
                    StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.LastName, searchString,
                    StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allPeople);
        }

        //GET: People/Details/1
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var personDetail = await _service.GetPersonByIdAsync(id);
            return View(personDetail);
        }

        //GET: People/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Welcome"] = "Welcome to F-Corp";
            ViewBag.Description = "This is the F-Corp description";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPersonVM person)
        {
            if(!ModelState.IsValid)
            {
                return View(person);
            }

            await _service.AddNewContactAsync(person);
            return RedirectToAction(nameof(Index));
        }

        //GET: People/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var contactDetails = await _service.GetPersonByIdAsync(id);
            if(contactDetails == null) return View("NotFound");

            var response = new NewPersonVM()
            {
                Id = contactDetails.Id,
                Name = contactDetails.Name,
                LastName = contactDetails.LastName,
                JobTitle = contactDetails.JobTitle,
                BusinessPhone = contactDetails.BusinessPhone,
                PersonalPhone = contactDetails.PersonalPhone,
                EmailAddress = contactDetails.EmailAddress,
                Address = contactDetails.Address,
                BloodType = contactDetails.BloodType,
                EmergencyPhone = contactDetails.EmergencyPhone,
                ImageURL = contactDetails.ImageURL,
                StartDate = contactDetails.StartDate,
            };

            ViewData["Welcome"] = "Welcome to F-Corp";
            ViewBag.Description = "This is the F-Corp description";
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPersonVM person)
        {
            if (id != person.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                return View(person);
            }

            await _service.UpdateContactAsync(person);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> ListView()
        {
            var allPeople = await _service.GetAllAsync();
            return View(allPeople);
        }
    }
}
