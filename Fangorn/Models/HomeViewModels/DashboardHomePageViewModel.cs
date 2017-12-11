using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ServiceOrderViewModels;
using Tower.Models.ClientViewModels;
using Tower.Models.ProjectViewModels;

namespace Tower.Models.HomeViewModels
{
    public class DashboardHomePageViewModel
    {

        //see service orders
        public int RecentServiceOrders { get; set; }
        //see project tasks done
        public List<ProjectTask> RecentProjectTasksComplete { get; set; } 
        
        //new clients
        public List<Client> RecentAddedClients { get; set; }
    }
}
