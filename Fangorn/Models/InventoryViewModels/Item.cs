using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.InventoryViewModels
{
    /// <summary>
    /// An item is owned by you.
    /// </summary>
    public class Item
    {

        public int Id { get; set; }
        
        public String Name { get; set; }

        public String Manufacturer { get; set; }

        public String Type { get; set; }

        public String Code { get; set; }

        public Decimal? Price { get; set; }

        public Decimal? Cost { get; set; }
        


    }
}
