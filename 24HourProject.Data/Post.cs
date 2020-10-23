using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public User Author { get; set; }
       
    }
}
