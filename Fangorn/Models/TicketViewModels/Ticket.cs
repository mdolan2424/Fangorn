using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.TicketViewModels
{
    public class Ticket
    {
        
        public int ID { get; set; }
        [Required]
        
        public string Title { get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(2000)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime CloseDate { get; set; }

        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
      

    }
}
