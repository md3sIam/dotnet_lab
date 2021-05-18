using System.Collections;
using System.Collections.Generic;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;

namespace Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ShopContext Db;
        public UserController()
        {
            Db = getDbContext();
        }
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Db.Users;
        }

        [HttpGet("{id}")]
        public User Get(long id)
        {
            return Db.Users.Find(id);
        }

        [HttpPut]
        public User Put(long id)
        {
            User user = new User();
            user.Id = id;
            Db.Users.Add(user);
            Db.SaveChanges();
            return user;
        }

        [HttpDelete]
        public long Delete(long id)
        {
            User user = Db.Users.Find(id);
            if (user == null)
                return -1;

            Db.Users.Remove(user);
            Db.SaveChanges();
            return id;
        }
        
        private static string GetConnString()
        {
            return $"server=localhost;uid=root;pwd={DataAccess.GetPassword(null)};database=shop";
        }

        private static ShopContext getDbContext()
        {
            return new ShopContext(GetConnString());
        }
    }
}