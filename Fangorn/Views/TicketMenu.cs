using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Views
{
    public class TicketMenu: IMenu
    {
        public List<String> Actions;
        public string Controller;

        public TicketMenu()
        {
            Actions = new List<String>();
            this.Controller = "Ticket";

            this.Actions.Add("Index");
            this.Actions.Add("Create");
            this.Actions.Add("Delete");

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
