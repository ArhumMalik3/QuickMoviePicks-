using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz.Models
{
    public class MovieRanking
    {
        [Key]
        public int Id { get; set; }

        public int MovieRating1 { get; set; }

        public int MovieRating2 { get; set; }

        public int MovieRating3 { get; set; }

        public int MovieRating4 { get; set; }

        public int MovieRating5 { get; set; }
    }
}
