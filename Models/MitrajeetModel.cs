using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrajeet_MVC.Models
{
    public class MitrajeetModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Age")]
        [Range(18, 100, ErrorMessage = "Age should be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter PhoneNumber")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Country")]
        public string Country { get; set; }
        // public IEnumerable<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Countries { get; set; }

        [Required(ErrorMessage = "Enter State")]
        public string State { get; set; }
        public List<SelectListItem> States { get; set; }
        //public IEnumerable<SelectListItem> States { get; set; }



    }
}
