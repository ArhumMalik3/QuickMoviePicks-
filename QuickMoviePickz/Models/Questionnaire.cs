using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz.Models
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }



        

        [Display(Name = "Director")]
        public string Director { get; set; }

        [Display(Name = "Actor")]
        public string Actor { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [ForeignKey("GenreId")]
        [Display(Name = "Genre")]
        public int genreId { get; set; }
        public GenreId Genre { get; set; }


        [NotMapped]
        public SelectList Genres { get; set; }

    }
}
