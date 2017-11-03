using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Views
{
    public class ServiceOrderMenu: IMenu
    {
        public List<String> Actions = new List<String>
        {
            "New",
            "Open",
            "Assigned",
            "Closed",
            "Archived"
        };

        public string Controller;

        public ServiceOrderMenu()
        {
            this.Controller = "ServiceOrder";
        }

        public String getController()
        {
            return this.Controller;
        }

        public List<String> getActions()
        {
            return this.Actions;
        }

        
        
    }
}
