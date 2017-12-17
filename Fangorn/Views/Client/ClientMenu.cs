using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Views.Clients
{
    public class ClientMenu : IMenu
    {

        public List<String> Actions = new List<String>
        {
            "Clients",
            "Create"
        };

        public string Controller;

        public ClientMenu()
        {
            this.Controller = "Client";
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
