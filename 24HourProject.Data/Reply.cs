using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class Reply : Comment
    {
        [Required]
        public Comment ReplyComment { get; set; }
        [Required]
        public int ReplyCommentId { get; set; }
    }
}
