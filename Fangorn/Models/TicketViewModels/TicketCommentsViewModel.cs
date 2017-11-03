using Tower.Models.TicketViewModels.CommentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.TicketViewModels
{
    public class TicketCommentsViewModel
    {
        public Ticket Ticket { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
