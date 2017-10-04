using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Views
{
    public class MenuFactory
    {
        public IMenu getMenu(string menuType)
        {
            if (menuType == "Default")
            {
                return new DefaultMenu();
            }

            if (menuType == "Ticket")
            {
                return new TicketMenu();
            }

            else if (menuType == "Home")
            {
                return new HomeMenu();
            }


            return null;
        }

    }
}
