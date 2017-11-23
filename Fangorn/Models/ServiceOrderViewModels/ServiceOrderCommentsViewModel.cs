using Tower.Models.ServiceOrderViewModels.CommentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ServiceOrderViewModels.BillableViewModels;

namespace Tower.Models.ServiceOrderViewModels
{
    public class ServiceOrderCommentsViewModel
    {
        public ServiceOrder ServiceOrder { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
        public List<BillableTime> BillableTimes { get; set; }
    }
}
