using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.InventoryViewModels
{
    /// <summary>
    /// An asset is something managed and/or owned by a client.
    /// </summary>
    public class Asset
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ManagedBy { get; set; }
    }
}
