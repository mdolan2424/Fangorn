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
            "Check In",
            "Log Time",
            "View Open Timelogs",
            "View Closed Timelogs"
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
