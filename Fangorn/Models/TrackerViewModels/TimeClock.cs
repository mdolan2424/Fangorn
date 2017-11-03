using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.TrackerViewModels
{
    public class TimeClock
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        


        public TimeClock()
        {

        }

        public void StartTimeLog()
        {
            StartTime = DateTime.Now;
        }

        public int GetElapsedTime()
        {
            if (StartTime != null)
            {
                return EndTime.Minute - StartTime.Minute;
            }

            else
            {
                return 0;
            }
                
            
        }

    }
}
