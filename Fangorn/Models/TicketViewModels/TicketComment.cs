using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fangorn.Models.TicketViewModels
{
    public class TicketComment
    {
        public int Id { get; set; }
        [ForeignKey("TicketId")]
        public Ticket ticket { get; set; }
        public ApplicationUser Commentor { get; set; }
        public DateTime Date { get; set; }
        public String Content { get; set; }



    }
}
