using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ClientViewModels;
using Tower.Models.InventoryViewModels;
using Tower.Models.TrackerViewModels;

namespace Tower.Models.ClientsViewModels
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public float Charge { get; set; }
        public TimeLog TimeLog { get; set; }
        public Client Client { get; set; }
        public Item Item { get; set; }
    }
}
