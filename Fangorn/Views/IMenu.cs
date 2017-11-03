using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Views
{
    public interface IMenu
    {
        String getController();
        List<String> getActions();
    }
}
