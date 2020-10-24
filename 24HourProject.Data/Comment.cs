using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _24HourProject.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public virtual User Author { get; set; }
        public int UserId { get; set; }
        [Required]
        [ForeignKey(nameof(PostId))]
        public virtual Post CommentPost { get; set; }
        public int PostId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }
    }
}