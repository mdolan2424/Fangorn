using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fangorn.Models.LocationViewModels;
using Fangorn.Models.ClientViewModels;

namespace Fangorn.Models.TrackerViewModels
{
    public class TimeLog
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LoggedMinutes { get; set; }
        public ApplicationUser User { get; set; }
        public Client Client { get; set; }
        
    }
}
