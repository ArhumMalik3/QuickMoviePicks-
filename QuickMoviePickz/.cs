using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMoviePickz
{
    public class Movie
    {
        public float elapse { get; set; }
        public int total { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string vtype { get; set; }
        public string img { get; set; }
        public int nfid { get; set; }
        public string imdbid { get; set; }
        public string title { get; set; }
        public string clist { get; set; }
        public string poster { get; set; }
        public float imdbrating { get; set; }
        public int top250tv { get; set; }
        public string synopsis { get; set; }
        public string titledate { get; set; }
        public float avgrating { get; set; }
        public int year { get; set; }
        public int runtime { get; set; }
        public int top250 { get; set; }
        public int id { get; set; }
    }
}




