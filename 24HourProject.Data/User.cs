using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _24HourProject.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Author { get; set; }
        public Guid OwnerId { get; set; }
    }
}