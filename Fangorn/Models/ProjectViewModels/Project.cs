using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tower.Models.ProjectViewModels
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        public Double PercentComplete { get; set; }
        [ForeignKey("TaskId")]
        public List<ProjectTask> Tasks { get; set; }
        
    }
}
