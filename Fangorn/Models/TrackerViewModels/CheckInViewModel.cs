using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ClientViewModels;

namespace Tower.Models.TrackerViewModels
{
    public class CheckInViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<SelectListItem> Clients { get; set; }
    }
}
