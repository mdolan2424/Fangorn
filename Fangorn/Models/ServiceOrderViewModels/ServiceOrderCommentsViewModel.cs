using Tower.Models.ServiceOrderViewModels.CommentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ServiceOrderViewModels.BillableViewModels;
using System.ComponentModel.DataAnnotations;

namespace Tower.Models.ServiceOrderViewModels
{
    public class ServiceOrderCommentsViewModel
    {
        public ServiceOrder ServiceOrder { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
        [DataType(DataType.Currency)]
        public double BillableCost { get; set; }
    }
}
