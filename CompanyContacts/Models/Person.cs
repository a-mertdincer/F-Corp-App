using CompanyContacts.Data.Enums;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using CompanyContacts.Data.Base;

namespace CompanyContacts.Models
{
    public class Person:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public JobTitles JobTitle { get; set; }

        public string BusinessPhone { get; set; }

        public string PersonalPhone { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public BloodTypes BloodType { get; set; }

        public string EmergencyPhone { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }


    }
}
