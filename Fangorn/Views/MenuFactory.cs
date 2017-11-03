using Tower.Views.Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Views
{
    public class MenuFactory
    {
        public IMenu getMenu(string menuType)
        {
            if (menuType == "Default")
            {
                return new DefaultMenu();
            }

            if (menuType == "ServiceOrder")
            {
                return new ServiceOrderMenu();
            }

            else if (menuType == "Home")
            {
                return new HomeMenu();
            }

            else if (menuType == "Tracker")
            {
                return new TrackerMenu();
            }


            return null;
        }

    }
}
