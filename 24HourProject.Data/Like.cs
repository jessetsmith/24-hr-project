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
        [Required]
        [ForeignKey(nameof(LikedPost))]
        public int PostId { get; set; }
        public virtual Post LikedPost { get; set; }
        [Required]
<<<<<<< HEAD
        [ForeignKey(nameof(User))]
        public Guid OwnerId { get; set; }
        public User Liker { get; set; }
        [Required]
        public int LikeId { get; set; }
=======
        [ForeignKey(nameof(Liker))]
        public int UserId { get; set; }
        public virtual User Liker { get; set; }
        [Key]
        public int LikeId { get; set; }
        public Guid OwnerId { get; set; }
>>>>>>> 3d3e17d34de7ee57a7573e96d111c6cefd99ef3a
    }
}
