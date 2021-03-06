﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.LocationViewModels
{
    public class CreateAddressViewModel
    {
        [Required]
        public String Street { get; set; }

        public String Line2 { get; set; }

        [Required]
        public String City { get; set; }

        //dropdown
        [Required]
        public String State { get; set; }

        //dropdown
        [Required]
        public String Country { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip code.")]
        public String Zip { get; set; }

        public List<SelectListItem> States { get; set; }
        
        public List<String> ListOfCountries { get; set; }

        
    }
}
