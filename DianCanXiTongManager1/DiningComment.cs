using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    class DiningComment
    {
        public int id { get; set; }
        public int RestaurantId { get; set; }
        public string DiningComments { get; set; }
        public double DiningGrade { get; set; }
        public int ClientId { get; set; }
    }
}
