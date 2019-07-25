using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginInfoesController : ControllerBase
    {
        private readonly DBContext _context;

        public UserLoginInfoesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/UserLoginInfoes
        [HttpGet]
        public IEnumerable<UserLoginInfo> GetUserLoginInfo()
        {
            return _context.UserLoginInfo;
        }

        // GET: api/UserLoginInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserLoginInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLoginInfo = await _context.UserLoginInfo.FindAsync(id);

            if (userLoginInfo == null)
            {
                return NotFound();
            }

            return Ok(userLoginInfo);
        }

        // PUT: api/UserLoginInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLoginInfo([FromRoute] int id, [FromBody] UserLoginInfo userLoginInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLoginInfo.SerialNo)
            {
                return BadRequest();
            }

            _context.Entry(userLoginInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserLoginInfoes
        [HttpPost]
        public async Task<IActionResult> PostUserLoginInfo([FromBody] UserLoginInfo userLoginInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserLoginInfo.Add(userLoginInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLoginInfo", new { id = userLoginInfo.SerialNo }, userLoginInfo);
        }


        // DELETE: api/UserLoginInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLoginInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLoginInfo = await _context.UserLoginInfo.FindAsync(id);
            if (userLoginInfo == null)
            {
                return NotFound();
            }

            _context.UserLoginInfo.Remove(userLoginInfo);
            await _context.SaveChangesAsync();

            return Ok(userLoginInfo);
        }

        private bool UserLoginInfoExists(int id)
        {
            return _context.UserLoginInfo.Any(e => e.SerialNo == id);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("check")]
        public String CheckUserAsync([Microsoft.AspNetCore.Mvc.FromBody] UserLoginInfo userLoginInfo)
        {
            // var user = await _context.UserLoginInfo.FindAsync(userLoginInfo.SerialNo);
            UserLoginInfo user = _context.UserLoginInfo.SingleOrDefault(userdata => userdata.Email == userLoginInfo.Email);
            var s = user;
            if (user == null )
            {
                return "not found";
            }
            if(user.Password !=userLoginInfo.Password)
            {
                return "invalid passowrd";
            }
            return "found";
      
        }
    }
}