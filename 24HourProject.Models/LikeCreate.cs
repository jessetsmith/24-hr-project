using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class LikeCreate
    {
        [Required]
        [ForeignKey(nameof(Post))]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public Post LikedPost { get; set; }            

        public User Liker { get; set; }
    }
}
