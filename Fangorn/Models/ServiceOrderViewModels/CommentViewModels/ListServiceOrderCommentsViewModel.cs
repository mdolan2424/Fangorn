using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tower.Models.ServiceOrderViewModels.CommentViewModels
{
    public class ListServiceOrderCommentsViewModel
    {
        public ServiceOrder ServiceOrder { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}
