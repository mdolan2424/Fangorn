using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ClientViewModels;

namespace Tower.Models.TrackerViewModels
{
    public class CheckOutViewModel
    {
        public ApplicationUser User { get; set; }
        public Client Client { get; set; }
        public DateTime DateTime { get; set; }
    }
}
