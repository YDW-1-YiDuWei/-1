﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class CuisineComment
    {
        public int id { get; set; }
        public int CuisineId { get; set; }
        public string CuisineComments { get; set; }
        public int CuisineRate { get; set; }
        public int ClientId { get; set; }
    }
}