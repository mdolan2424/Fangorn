using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Views.Tracker
{
    public class TrackerMenu: IMenu
    {
        public List<String> Actions = new List<String>
        {
            "Log Time",
            "View Log",
        };

        public string Controller;

        public TrackerMenu()
        {
            this.Controller = "Tracker";
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
