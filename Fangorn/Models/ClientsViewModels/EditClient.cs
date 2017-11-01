using Fangorn.Models.LocationViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.ClientViewModels
{
    public class EditClient
    {
        public int Id { get; set; }

        [Display(Name="Client Name")]
        public string Name { get; set; }

        [Display(Name="Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name="Phone Number")]
        public string Phone { get; set; }

        [Display(Name="Mailing Address")]
        public Address Address { get; set; }

        [Display(Name="Main Person of Contact")]
        public Contact MainContact { get; set; }
    }
}
