﻿using Tower.Models.ClientViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ClientViewModels
{
    public class ListClients
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}
