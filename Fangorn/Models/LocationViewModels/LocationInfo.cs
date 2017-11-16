using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Tower.Models.LocationViewModels
{
    public class LocationInfo
    {



   


        public void CountryList()
        {
            List<String> ListOfCountries = new List<String>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(ListOfCountries.Contains(R.EnglishName)))
                {
                    ListOfCountries.Add(R.EnglishName);
                }
            }

            ListOfCountries.Sort();
        }
    }
}
