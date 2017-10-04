using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fangorn.Models.TicketViewModels.CommentViewModels
{
    public class ListTicketCommentsViewModel
    {
        public Ticket Ticket { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}
