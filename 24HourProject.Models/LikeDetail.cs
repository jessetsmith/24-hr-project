﻿using _24HourProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProject.Models
{
    public class LikeDetail
    {
        public Post LikedPost { get; set; }
        public User Liker { get; set; }
    
    }
}
