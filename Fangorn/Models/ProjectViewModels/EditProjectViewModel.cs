using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ProjectViewModels
{
    public class EditProjectViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }
    }
}
