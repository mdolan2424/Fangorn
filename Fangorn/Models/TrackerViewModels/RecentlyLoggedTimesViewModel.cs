using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.TrackerViewModels
{
    public class RecentlyLoggedTimesViewModel
    {
        public IEnumerable<TimeLog> Times { get; set; }
    }
}
