using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Fangorn.Models.ClientViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Fangorn.Models.TicketViewModels
{
    
    public class CreateTicketViewModel
    {
        
        [Required(ErrorMessage = "Please enter a Title.")]
        [MinLength(0)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Due Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [ForeignKey("AssignedId")]
        public string AssignedTo { get; set; }

        [ForeignKey("OpenUserId")]
        public ApplicationUser Creator { get; set; }

        [Display(Name = "Tech Assignment")]
        public SelectList TeamMembers { get; set; }

        
    }
}