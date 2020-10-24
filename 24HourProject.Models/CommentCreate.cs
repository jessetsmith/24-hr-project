using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class CommentCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 characters.")]
        [MaxLength(400, ErrorMessage = "There are too many characters in this field.")]
        public string Text { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        public Post CommentPost { get; set; }
    }
}
