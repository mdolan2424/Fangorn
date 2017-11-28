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
        public string Type { get; set; } //revisit
        public string Status { get; set; }
        public int StoryPoints { get; set; }
        public int Complexity { get; set; }
        public bool InWork { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
