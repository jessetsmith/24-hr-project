using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class UserListItem
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedUtc { get; set; }


    }
}
