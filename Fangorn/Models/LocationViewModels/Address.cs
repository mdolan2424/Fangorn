﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.LocationViewModels
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public String Street { get; set; }
        
        public String Apartment { get; set; }

        [Required]
        public String City { get; set; }

        //dropdown
        [Required]
        public String State { get; set; }

        //dropdown
       
        public String Country { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip code.")]
        public String Zip { get; set; }
        
    }
}
