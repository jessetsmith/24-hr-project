using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
   public class LikeListItem
    {
        [ForeignKey(nameof(Post))]
        public Post LikedPost { get; set; }
        [ForeignKey(nameof(User))]
        public User Liker { get; set; }
    }
}
