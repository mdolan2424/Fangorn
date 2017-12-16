using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.SettingsViewModels
{
    public class Settings
    {
        public int Id { get; set; }
        public String SiteName { get; set; }
        public double ChargeRate { get; set; }
    }
}
