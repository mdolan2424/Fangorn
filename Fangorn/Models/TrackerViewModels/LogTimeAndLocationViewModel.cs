using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fangorn.Models.ClientViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fangorn.Models.TrackerViewModels
{
    public class LogTimeAndLocationViewModel
    {
        public ApplicationUser User { get; set; }
        public TimeLog Time { get; set; }
        public SelectList Clients {get;set;}
    }
}
