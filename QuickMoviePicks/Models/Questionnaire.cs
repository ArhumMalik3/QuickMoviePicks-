using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePicks.Models
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Genre")]
        public string genre { get; set; }

        [Display(Name = "Director")]
        public string director { get; set; }

        [Display(Name = "Actor")]
        public string actor { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }
    }
}
