using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tower.Models.TeamViewModels;

namespace Tower.Models.ProjectViewModels
{
    public class EditProjectViewModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        public Team Team { get; set; }

        public IEnumerable<SelectListItem> AllTeams { get; set; }
    }
}
