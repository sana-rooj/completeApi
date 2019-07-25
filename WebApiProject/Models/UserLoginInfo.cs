using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class UserLoginInfo
    {
        [Key]
        public int SerialNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

       
    }
}
