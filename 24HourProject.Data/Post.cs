using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Text { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public int Author { get; set; }
        public virtual User UserId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }
    }
}
