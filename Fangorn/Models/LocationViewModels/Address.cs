using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.LocationViewModels
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Address Line 1")]
        public String Line1 { get; set; }
        
        [Display(Name = "Address Line 2")]
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
        
    }
}
