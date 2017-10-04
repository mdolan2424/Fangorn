using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Views
{
    public class HomeMenu : IMenu
    {
        public List<String> Actions;
        public string Controller;

        public List<string> getActions()
        {
            Actions = new List<String>();
            this.Controller = "Ticket";

            this.Actions.Add("Index");
            this.Actions.Add("About Us");
            this.Actions.Add("Contact Us");

            return Actions;
        }

        public string getController()
        {
            return "Home";
        }
    }
}
