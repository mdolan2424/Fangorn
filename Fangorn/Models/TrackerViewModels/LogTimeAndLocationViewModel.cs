using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Tower.Models.ClientViewModels;

namespace Tower.Models.TrackerViewModels
{
    public class LogTimeAndLocationViewModel
    {
        [Required]
        [Display(Name = "Starting Time")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Ending Time")]
        public DateTime EndTime { get; set; }
        [Required]
        [Display(Name = "Total Minutes")]
        public int LoggedMinutes { get; set; }
        public ApplicationUser User { get; set; }
        public int ClientId { get; set; }
        [Required]
        [Display(Name = "Select a Client")]
        public List<Client> AllClients { get; set; }
    }
}
