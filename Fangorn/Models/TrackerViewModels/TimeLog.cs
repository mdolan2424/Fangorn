using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.LocationViewModels;
using Tower.Models.ClientViewModels;
using System.ComponentModel.DataAnnotations;

namespace Tower.Models.TrackerViewModels
{
    public class TimeLog
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int LoggedMinutes { get; set; }
        public DateTime PausedTime { get; set; }
        public DateTime ContinueTime { get; set; }
        public List<TimeSession> Sessions { get; set; }
        public ApplicationUser User { get; set; }
        public Client Client { get; set; }
    }
}
