using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    class CuisineInformations
    {
        public int id { get; set; }
        public string CuisineName { get; set; }
        public int RestaurantId { get; set; }
        public int CuisineTypeId { get; set; }
        public double CuisinePrice { get; set; }
        public int CuisineCommentId { get; set; }
        public int CuisineCount { get; set; }
        public string CuisineImagePath { get; set; }
    }
}
