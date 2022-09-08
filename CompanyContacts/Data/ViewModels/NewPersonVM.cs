using CompanyContacts.Data.Enums;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using CompanyContacts.Data.Base;

namespace CompanyContacts.Models
{
    public class NewPersonVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Contact Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [Display(Name = "Contact Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Job Title is required.")]
        [Display(Name = "Contact Job Title")]
        public JobTitles JobTitle { get; set; }

        [Required(ErrorMessage = "Business Phone Number is required.")]
        [Display(Name = "Contact Business Phone")]
        public string BusinessPhone { get; set; }

        [Required(ErrorMessage = "Personal Phone Number is required.")]
        [Display(Name = "Contact Personal Number")]
        public string PersonalPhone { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Contact Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Contact Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Blood Type is required.")]
        [Display(Name = "Contact Blood Type")]
        public BloodTypes BloodType { get; set; }

        [Required(ErrorMessage = "Emergency Phone Number is required.")]
        [Display(Name = "Contact Emergency Phone Number")]
        public string EmergencyPhone { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Display(Name = "Contact Image")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [Display(Name = "Contact Start Date")]
        public DateTime StartDate { get; set; }


    }
}
