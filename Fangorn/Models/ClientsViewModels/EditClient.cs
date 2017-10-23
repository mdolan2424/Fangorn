using Fangorn.Models.LocationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.ClientViewModels
{
    public class EditClient
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }

        public Address Address { get; set; }
        public Contact MainContact { get; set; }
    }
}
