using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class CuisineInformations
    {
        public int id { get; set; }
        public string CuisineName { get; set; }
        public CuisineComment RestaurantId { get; set; }
        public CuisineType CuisineTypeId { get; set; }
        public double CuisinePrice { get; set; }
        public CuisineComment CuisineCommentId { get; set; }
        public int CuisineCount { get; set; }
        public string CuisineImagePath { get; set; }
    }
}
