using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Data
{
    public class SqlFacade
    {
        public int SomeSetting
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager)
            }
        }
    }
}
