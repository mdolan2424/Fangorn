﻿using Fangorn.Models.LocationViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.ClientViewModels
{
    public class ManageClient
    {
        [Required]
        [Display(Name = "Client Name")]
        public String Name { get; set; }

        public String MainContact { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Contact Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter a valid Phone number")]
        public String Phone { get; set; }

        [Required]
        public Address Address { get; set; }

        public Company Company { get; set; }

        [Required]
        public String ClientManager { get; set; }

        //client password file

        //balance

        //tickets

        //geolocation

    }
}