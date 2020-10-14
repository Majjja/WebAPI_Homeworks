using MoviesWebApi_Homework02.Enums;
using MoviesWebApi_Homework02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MoviesWebApi_Homework02
{
    public static class StaticDb
    {
        public static List<Movie> ListOfMovies = new List<Movie>()
        {
            new Movie()
            {
                Id = 1,
                Title = "Peaceful Warrior",
                Genre = Genre.Drama,
                Duration = 120,
                Artists = new List<string>(){ "Scott Mechlowicz", "Nick Nolte", "Amy Smart", "Tim DeKay", "Ashton Holmes" }
            },
            new Movie()
            {
                Id = 2,
                Title = "Togo",
                Genre = Genre.Adventure,
                Duration = 113,
                Artists = new List<string>(){ "Willem Dafoe", "Julianne Nicholson", "Christopher Heyerdahl" }
            },
            new Movie()
            {
                Id = 3,
                Title = "Enola Holmes",
                Genre = Genre.Adventure,
                Duration = 123,
                Artists = new List<string>(){ "Millie Bobby Brown", "Henry Cavill", "Sam Claflin" }
            },
            new Movie()
            {
                Id = 4,
                Title = "Secondhand Lions",
                Genre = Genre.Comedy,
                Duration = 109,
                Artists = new List<string>(){ "Haley Joel Osment", "Michael Caine", "Robert Duvall" }
            },
            new Movie()
            {
                Id = 5,
                Title = "The Devil's Advocate",
                Genre = Genre.Drama,
                Duration = 144,
                Artists = new List<string>(){ "Keanu Reeves", "Al Pacino", "Charlize Theron" }
            }
        };
    }
}
