using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Context;
using Task1.Model;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;
      
        public UserController(DatabaseContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        public async Task<User> AddUser(User user)
        {

            User newUser = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Department = user.Department
            };

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            
            return newUser;
        }

        [HttpDelete]

        public void  DeleteUser(int id)
        {
            var user = _context.users.FindAsync(id).Result;
            _context.Remove(user);
            _context.SaveChanges();
        }

        [HttpPut]

        public void UpdateUser(User user)
        {

            User newUser = new User
            {
                Id=user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Department = user.Department
            };

            _context.Update(newUser);
            _context.SaveChanges();
        }

        [HttpGet]

        public  IEnumerable<User> ListAll()
        {
            List<User> user;
            user = _context.users.ToList();
            return user;
        }
    }
}
