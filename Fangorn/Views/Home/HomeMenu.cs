using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Views
{
    public class HomeMenu : IMenu
    {
        public List<String> Actions = new List<String>
        {
            
        };
        public string Controller;

        public List<string> getActions()
        {
            return this.Actions;
        }

        public string getController()
        {
            return this.Controller;
        }
    }
}
