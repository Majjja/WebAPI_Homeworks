using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MoviesWebApi_Homework02.Models;

namespace MoviesWebApi_Homework02.Controllers
{
    #region Homework Task
    //1. Create new WEB API project
    //2. Add new MoviesController
    //3. Create static database of Movie(model) containing id, name, genre and duration, artists (list of artist's names)
    //4. Add GET method that returns all movies
    //5. Add GET method that returns one movie by id with path variable(route parametar)
    //6. Add POST method that adds new movie through body. (use FromBody attribute)
    //7. Add GET method that returns movie by specific name using query parametar

    //Bonus
    //  Add GET method that accepts "id" as path variable and "name" as query parametar.Return all artists from that specific movie with names starting as the "name"- the query parametar.
    //  Add GET method with specific route that returns all movies and if in the header Accept-language is "mk-MK" in the response
    //provide a message "Во респонсот се вклучени сите филмови кои ги чуваме во датабаза", otherwise in the response provide a message "In the response are included all artists that are stored in the database"
    #endregion
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return StaticDb.ListOfMovies;
        }

        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            try
            {
                var movie = StaticDb.ListOfMovies.SingleOrDefault(x => x.Id == id);
                if (movie == null) throw new Exception($"There is no movie with an id {id}");
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet]
        [Route("getByName")]
        public ActionResult<Movie> Get([FromQuery] string name)
        {
            try
            {
                var movie = StaticDb.ListOfMovies.FirstOrDefault(x => x.Title.ToLower() == name.ToLower());
                if (movie == null) throw new Exception($"There is no movie with a name \"{name}\"");
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            try
            {
                var existingMovie = StaticDb.ListOfMovies.SingleOrDefault(x => x.Id == movie.Id);
                if(existingMovie == null)
                {
                    StaticDb.ListOfMovies.Add(movie);
                    return Ok("Movie successfully added.");
                }
                throw new Exception($"Movie with id {movie.Id} already exists.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("getArtistNames/{id}")]
        public ActionResult<List<string>> GetArtistNames([FromRoute] int id, [FromQuery] string name)
        {
            try
            {
                var movie = StaticDb.ListOfMovies.SingleOrDefault(x => x.Id == id);
                if (movie == null)
                    throw new Exception($"There are is no movie with id {id}");

                var artists = movie.Artists.Where(x => x.StartsWith(name)).ToList();
                if (artists.Count() == 0)
                    throw new Exception($"There are no artists with name {name} in the movie \"{movie.Title}\"");

                return Ok(artists);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

        }

        [HttpGet]
        [Route("getAllMovies")]
        public ActionResult<List<Movie>> GetAllMovies([FromHeader(Name = "Accept-language")] string lng)
        {
            if(lng == "mk-MK")
                return StatusCode(StatusCodes.Status200OK, "Во респонсот се вклучени сите филмови кои ги чуваме во датабаза");
            return StatusCode(StatusCodes.Status200OK, "In the response are included all artists that are stored in the database");
        }
    }
}
