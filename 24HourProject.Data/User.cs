using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Author))]
        public ICollection<Post> Posts { get; set; }
        public User Author { get; set; }
        public Guid OwnerId { get; set; }
    }
}
