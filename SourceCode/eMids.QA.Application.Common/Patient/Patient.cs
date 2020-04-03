using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eMids.QA.Application.Common
{
    public class Patient
    {
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Member Id")]
        [Required]
        public string MemberId { get; set; }

        public string Identifier { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public List<SelectListItem> Genders = new List<SelectListItem> { new SelectListItem { Text = "Male", Value = "Male" }, new SelectListItem { Text = "Female", Value = "Female" } };

    }
}