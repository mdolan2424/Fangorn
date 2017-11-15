using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.InventoryViewModels
{
    public class CreateItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Cost { get; set; }
    }
}
