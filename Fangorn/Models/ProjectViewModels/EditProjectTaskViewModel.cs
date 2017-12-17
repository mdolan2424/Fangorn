using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ProjectViewModels
{
    public class EditProjectTaskViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Display(Name = "Story Points")]
        public int StoryPoints { get; set; }
        [Display(Name = "Complexity Points")]
        public int Complexity { get; set; }

        [Display(Name = "Date of Completion")]
        public DateTime CompletionDate { get; set; }

        public Status Status { get; set; }
       
    }
}
