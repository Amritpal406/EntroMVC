using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entro.Models
{
    public class Concepts
    {
        // concept table model working 
        public int Id { get; set; }

        [Display(Name = "ConceptName")]
        public string ConceptName { get; set; }

        [Display(Name = "Time")]
        public string Time { get; set; }


        [Display(Name = "TicketRate ")]
        public string TicketRate { get; set; }


    }
}
