using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class Permission
    {
        [Key]
        public int index { get; set; }
        public string pageName { get; set; }
        public string pageUrl  {get;set;}
        public string pagePermission { get; set; }

    }
}
