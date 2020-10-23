using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [Required]
        //[ForeignKey(nameof(Post))]
        public Post LikedPost { get; set; }
        [Required]
        //[ForeignKey(nameof(User))]
        public User Liker { get; set; }
    }
}
