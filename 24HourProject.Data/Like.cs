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
        [ForeignKey(nameof(Liker))]
        public int UserId { get; set; }
        public virtual User Liker { get; set; }
        [Key]
        public int LikeId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
