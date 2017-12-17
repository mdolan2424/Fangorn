using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.TeamViewModels;

namespace Tower.Models.ProjectViewModels
{
    public class ProjectTask
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
       
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        [Display(Name ="Story Points")]
        public int StoryPoints { get; set; }
        [Display(Name ="Complexity Points")]
        public int Complexity { get; set; }
        [Display(Name ="Date of Completion")]
        public DateTime CompletionDate { get; set; }
        [Display(Name = "Completed By")]
        public ApplicationUser CompletedBy { get; set; }
        [ForeignKey("ProjectId")]
        [Display(Name ="Project ID")]
        public Project Project { get; set; }
    }

    public enum Status
    {
        [Display(Name = "Incomplete")]
        Incomplete = 1,

        [Display(Name = "In Work")]
        InWork = 2,

        [Display(Name = "Complete")]
        Complete = 3
    };
}
