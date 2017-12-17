using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.TeamViewModels;

namespace Tower.Models.ProjectViewModels
{
    public class CreateProjectViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Team Name")]
        public Team Team { get; set; }
        [Required]
        public IEnumerable<SelectListItem> AllTeams { get; set; }
    }
}
