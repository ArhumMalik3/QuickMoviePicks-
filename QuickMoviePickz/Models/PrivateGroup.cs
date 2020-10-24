using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz.Models
{
    public class PrivateGroup
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Pin")]
        public int Pin { get; set; }

        [ForeignKey("MovieRanking")]
        public int? MovieRankingId { get; set; }
        public MovieRanking MovieRanking { get; set; }
    }
}
