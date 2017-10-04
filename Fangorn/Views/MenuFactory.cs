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
            if (menuType == "Ticket")
            {
                return new TicketMenu();
            }

            else if (menuType == null)
            {
                return new HomeMenu();
            }


            return null;
        }

    }
}
