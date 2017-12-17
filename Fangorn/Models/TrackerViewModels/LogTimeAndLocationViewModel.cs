using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Tower.Models.ClientViewModels;

namespace Tower.Models.TrackerViewModels
{
    public class LogTimeAndLocationViewModel
    {
        [Display(Name = "Starting Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Ending Time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Total Minutes")]
        public int LoggedMinutes { get; set; }
        public ApplicationUser User { get; set; }
        public int ClientId { get; set; }
        [Display(Name = "Select a Client")]
        public List<Client> AllClients { get; set; }
    }
}
