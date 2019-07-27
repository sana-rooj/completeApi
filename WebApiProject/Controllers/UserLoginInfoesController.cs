using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApiProject.Data;
using WebApiProject.Models;
using MailKit.Net.Smtp;
using MimeKit;
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
            Encypt encyptObj = new Encypt();
            // var user = await _context.UserLoginInfo.FindAsync(userLoginInfo.SerialNo);
            UserLoginInfo user = _context.UserLoginInfo.SingleOrDefault(userdata => userdata.Email == userLoginInfo.Email);
            var s = user;
            if (user == null)
            {
                return "not found";
            }
            if (encyptObj.DecryptString(user.Password, "E546C8DF278CD5931069B522E695D4F2") != userLoginInfo.Password)
            {
                return "invalid passowrd";
            }
            return "found";

        }
        // GET: api/UserLoginInfoes
        [HttpPost("forget")]
        public void forgetlink([FromBody] UserLoginInfo user)
        {
            string emailToSet = user.Email;
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("AngularApp",
            "Angular505@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User",
            emailToSet);
            message.To.Add(to);

            message.Subject = "Reset Password";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Please follow the link to Change password http://localhost:4000/forget-password";
            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587 , false);
            client.Authenticate("angular505@gmail.com", "Angular12*");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
        [HttpPut("reset")]
        public UserLoginInfo PutAsync([FromBody] UserLoginInfo userLoginInfo)
        {
            Encypt Eobj = new Encypt();
            UserLoginInfo user = _context.UserLoginInfo.SingleOrDefault(userdata => userdata.Email == userLoginInfo.Email);
            if(user==null) {
                return null;

            }
            userLoginInfo.Password = Eobj.EncryptString(userLoginInfo.Password , "E546C8DF278CD5931069B522E695D4F2");
            UserLoginInfo EditUser = new UserLoginInfo();
            EditUser.SerialNo = user.SerialNo;
            EditUser.Email = userLoginInfo.Email;
            EditUser.Password = userLoginInfo.Password;
            return EditUser;
           

        }


    }
}