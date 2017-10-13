using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Views
{
    public class TicketMenu: IMenu
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

        public TicketMenu()
        {
            this.Controller = "Ticket";
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
