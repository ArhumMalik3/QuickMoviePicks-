using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz.Models
{
    public class GenreId
    {
        [Key]
        public int Id { get; set; }

        
        public string Genre { get; set; }

        public string NetflixId { get; set; }
    }
}
