using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class Distribution
    {
        public int id { get; set; }//标识列ID
        public int RiderId { get; set; }//骑手ID 
        public int CuisineId { get; set; }//菜品ID 
        public int ClientId { get; set; }//客户表ID
        public int RestaurantId { get; set; }//餐馆ID
    }
}
