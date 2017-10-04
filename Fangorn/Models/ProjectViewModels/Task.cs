using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fangorn.Models.ProjectViewModels
{
    public class Task
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public Boolean Completed { get; }
        public ApplicationUser CompletedBy { get; }



    }
}
