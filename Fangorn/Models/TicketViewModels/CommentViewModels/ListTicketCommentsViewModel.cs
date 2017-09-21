using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fangorn.Models.TicketViewModels.CommentViewModels
{
    public class ListTicketCommentsViewModel
    {
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
