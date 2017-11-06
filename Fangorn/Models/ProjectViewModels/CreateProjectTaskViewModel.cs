﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tower.Models.ProjectViewModels
{
    public class CreateProjectTaskViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Type { get; set; } //revisit
        public string Status { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}