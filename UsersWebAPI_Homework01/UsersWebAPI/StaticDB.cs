using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UsersWebAPI.Models;

namespace UsersWebAPI
{
    public static class StaticDB
    {
        public static List<User> ListOfUsers = new List<User>()
        {
                new User()
                {
                    Id = 1,
                    FirstName = "Goce",
                    LastName = "Kabov"
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Darko",
                    LastName = "Pancevski"
                }
        };
    }
}
