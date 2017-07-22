using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Fangorn.Models.ClientViewModels;
namespace Fangorn.Models.TicketViewModels
{
    public class Ticket
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Title.")]
        public string Title { get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(2000)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public DateTime CloseDate { get; set; }
        
        public String UserId { get; set; }
        
        [ForeignKey("AssignedId")]
        public ApplicationUser AssignedTo { get; set; }

        [ForeignKey("OpenUserId")]
        public ApplicationUser Creator { get; set; }

        [ForeignKey("ClosedUserId")]
        public ApplicationUser ClosedBY { get; set; }

        public Contact contact { get; set; }

        public IEnumerable<TicketComment> comments { get; }

        

    }
}
