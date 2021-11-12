using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi_personelDemo.Context;
using webApi_personelDemo.Model;

namespace webApi_personelDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly DatabaseContext _context;
      
        public PersonelController(DatabaseContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        public async Task<Personel> AddUser(Personel user)
        {

            Personel newUser = new Personel
            {
                Name = user.Name,
                Surname = user.Surname,
                Department = user.Department
            };

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            
            return newUser;
        }

        [HttpGet("GetById/{id}")]
        public async Task<Personel> returnId(int id)
        {
            var user = _context.Personels.FindAsync(id).Result;
            return user;
        }

        [HttpDelete]

        public void  DeleteUser(int id)
        {
            var user = _context.Personels.FindAsync(id).Result;
            _context.Remove(user);
            _context.SaveChanges();
        }

        [HttpPut]

        public void UpdateUser(Personel user)
        {

            Personel newUser = new Personel
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

        public  IEnumerable<Personel> ListAll()
        {
            List<Personel> user;
            user = _context.Personels.ToList();
            return user;
        }

    }
}
