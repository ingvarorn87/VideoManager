﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoManagerDAL.Entities
{
    public class Video
    {
        public string VideoName { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
    }
}
