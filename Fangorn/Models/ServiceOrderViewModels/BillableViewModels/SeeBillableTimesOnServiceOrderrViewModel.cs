using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ServiceOrderViewModels.BillableViewModels
{
    public class SeeBillableTimesOnServiceOrderrViewModel
    {
        public ServiceOrder ServiceOrder { get; set; }
        public List<BillableTime> BillableTimes { get; set; }
    }
}
