using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ServiceOrderViewModels.BillableViewModels
{
    public class CreateBillableTimeViewModel
    {
        public int Minutes { get; set; }
        public String WorkPerformed { get; set; }
        public ServiceOrder ServiceOrder { get; set; }
        public ApplicationUser AddedBy { get; set; }
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
    }
}
