using QuickMoviePickz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz.ViewModels
{
    public class PrivateGroupRankMoviesViewModel
    {
        public PrivateGroup PrivateGroup { get; set; }

        public int GroupId { get; set; }

        public List<MovieWatcher> MovieWatchers { get; set; }

        public int MovieRating1 { get; set; }

        public int MovieRating2 { get; set; }

        public int MovieRating3 { get; set; }

        public int MovieRating4 { get; set; }

        public int MovieRating5 { get; set; }
    }
}
