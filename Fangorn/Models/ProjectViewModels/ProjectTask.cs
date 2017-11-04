using System;
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
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Type { get; set; } //revisit
        public string Status { get; set; }
        public string Priority { get; set; }
        public int StoryPoints { get; set; }
        public int Complexity { get; set; }
        public bool InWork { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float CompletionPercentage { get; set; }
        public Boolean Completed { get; }
        public ApplicationUser CompletedBy { get; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public List<ProjectTask> Dependencies { get; set; }
        public Team AssignedTeam { get; set; }
    }
}
