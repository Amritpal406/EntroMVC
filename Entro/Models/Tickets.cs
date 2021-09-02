using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entro.Models
{
    public class Tickets
    {
        // ticket booking table model working 
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Contact ")]
        public string Contact { get; set; }

        [Display(Name = "Number Of Persons")]
        public string NumberOfPersons { get; set; }

        [Display(Name = "Date")]
        public string Date { get; set; }

        // concept id from cocept table

        [Display(Name = "ConceptId")]
        public int ConceptId { get; set; }
    }
}
