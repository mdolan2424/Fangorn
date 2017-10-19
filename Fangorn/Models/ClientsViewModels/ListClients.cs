using Fangorn.Models.ClientViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.ClientsViewModels
{
    public class ListClients
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}
