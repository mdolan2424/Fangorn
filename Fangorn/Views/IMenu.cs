using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Views
{
    public interface IMenu
    {
        String getController();
        List<String> getActions();
    }
}
