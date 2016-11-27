using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using System.Linq;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private DatabaseContext _context;

        public ValuesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            using (var context = _context)
            {
                var result = (from item in context.Users
                              select new
                              {
                                  id = item.Id,
                                  name = item.Name,
                                  email = item.Email
                              }).ToList();
                return Json(result);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            using (var context = _context)
            {
                var result = (from item in context.Users
                              where item.Id == id
                              select new
                              {
                                  id = item.Id,
                                  name = item.Name,
                                  email = item.Email
                              }).First();
                return Json(result);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            using (var context = _context)
            {
                var user = new User();
                var dateTimeNow = DateTime.Now;
                var timestamp = dateTimeNow.Ticks;
                var id = 4;
                user.Id = id;
                user.Name = dateTimeNow.ToString("dd-mm-yyyy-SS");
                user.Email = timestamp + "@gmail.com";

                var role = new Role
                {
                    Id = id,
                    Name = "Role : " + id
                };

                var userRoles = new List<UserRole>();
                userRoles.Add(
                    new UserRole
                    {
                        User = user,
                        Role = role
                    }
                );
                user.UserRoles = userRoles;

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
