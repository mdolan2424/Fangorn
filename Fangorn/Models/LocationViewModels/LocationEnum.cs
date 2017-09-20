using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.LocationViewModels
{
    public class LocationEnum
    {
        public class CountryModel
        {
            public List<State> States { get; set; }
            public SelectList Cities { get; set; }
        }

        public class State
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class City
        {
            public int Id { get; set; }
            public int State { get; set; }
            public string Name { get; set; 
        }


    }
}
