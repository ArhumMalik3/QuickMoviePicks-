using QuickMoviePickz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz.ViewModels
{
    public class PrivateGroupDetailsViewModel
    {
        public PrivateGroup PrivateGroup { get; set; }

        public List<MovieWatcher> MovieWatchers { get; set; }
    }
}
