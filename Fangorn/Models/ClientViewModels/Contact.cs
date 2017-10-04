﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fangorn.Models.ClientViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Fangorn.Models.ClientViewModels
{
    public class Contact
    {


        public int Id {get;set;}

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }
        
        [Phone]
        public String Phone { get; set; }

        [ForeignKey("ClientID")]
        public Client Client { get; set; }

    }
}
