using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class Reservation
    {
        public int id { get; set; }//标识列ID 
        public int ClientId { get; set; }//用户ID
        public double Money { get; set; }//费用信息 
        public int CuisineInformationId { get; set; }//菜品信息ID 
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderListId { get; set; }
        /// <summary>
        /// 菜品数量
        /// </summary>
        public int VegetableQuantity { get; set; }
    }
}
