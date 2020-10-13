using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UsersWebAPI.Models;

namespace UsersWebAPI.Controllers
{
    #region Homework task
    //1. Create new WEB API project
    //2. Add new UsersController
    //3. Add static list of strings containing user names
    //4. Add GET method that returns all users
    //5. Add GET method that returns one user
    //6. Add POST method that adds new user
    //7. Add DELETE method that deletes a user

    //Bonus
    //Add model for User containing FirstName, LastName and Id
    //Add static list of user objects
    //Add GET method in the controller that returns list of User Objects
    //Add POST method that creates a new user
    #endregion
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK,StaticDB.ListOfUsers);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User user = StaticDB.ListOfUsers.SingleOrDefault(x => x.Id == id);
            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound, $"There is no user with id {id}");
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] User user)
        {
            var existingUser = StaticDB.ListOfUsers.SingleOrDefault(x => x.Id == user.Id);
            if (existingUser == null)
            {
                StaticDB.ListOfUsers.Add(user);
                return StatusCode(StatusCodes.Status201Created, "New user addded!");
            }
            return StatusCode(StatusCodes.Status409Conflict, $"There is already user with id {user.Id}");
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            var existingUser = StaticDB.ListOfUsers.SingleOrDefault(x => x.Id == user.Id);
            if(existingUser == null)
                return StatusCode(StatusCodes.Status409Conflict, $"There is no user with id {user.Id}");
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            return StatusCode(StatusCodes.Status200OK, $"User with Id {user.Id} successfully updated.");

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var user = StaticDB.ListOfUsers.SingleOrDefault(x => x.Id == id);
            if (user == null)
                return StatusCode(StatusCodes.Status409Conflict, $"There is no user with id {id}");
            StaticDB.ListOfUsers.Remove(user);
                return StatusCode(StatusCodes.Status200OK, $"User with Id {id} successfully deleted.");
        }
    }
}
