using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.TrackerViewModels
{
    public class TimeSession
    {
        public int Id { get; set; }
        public int Minutes { get; set; }
        public TimeLog TimeLog { get; set; }
    }
}
