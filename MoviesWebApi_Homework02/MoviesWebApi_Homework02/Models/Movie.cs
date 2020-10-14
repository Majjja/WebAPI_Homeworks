using MoviesWebApi_Homework02.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApi_Homework02.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int Duration { get; set; }
        public List<string> Artists { get; set; }
    }
}
