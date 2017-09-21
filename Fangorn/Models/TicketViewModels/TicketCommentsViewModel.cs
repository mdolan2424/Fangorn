using Fangorn.Models.TicketViewModels.CommentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.TicketViewModels
{
    public class TicketCommentsViewModel
    {
        public Ticket Ticket { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
