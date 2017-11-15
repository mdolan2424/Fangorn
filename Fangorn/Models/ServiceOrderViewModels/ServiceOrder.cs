using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.ClientViewModels;
using Tower.Models.ServiceOrderViewModels.CommentViewModels;

namespace Tower.Models.ServiceOrderViewModels
{
    public class ServiceOrder
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Title.")]
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

        public bool IsClosed { get; set; }

        [Display(Name = "Closed Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CloseDate { get; set; }
        
        public String UserId { get; set; }
        
        [ForeignKey("AssignedId")]
        [Display(Name = "Tech Assignment")]
        public ApplicationUser AssignedTo { get; set; }

        [ForeignKey("OpenUserId")]
        public ApplicationUser Creator { get; set; }

        [Display(Name = "Completed By")]
        [ForeignKey("ClosedUserId")]
        public ApplicationUser ClosedBy { get; set; }

        public String Contact { get; set; }
        
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public float TotalCharge { get; set; }
        

    }
}
