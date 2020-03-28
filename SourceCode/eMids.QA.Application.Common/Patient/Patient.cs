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
    }
}
