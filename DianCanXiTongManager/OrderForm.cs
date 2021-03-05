using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class OrderForm
    {
        public OrderForm()
        {
            Restaurant = new Restaurant();
            ClientId = new Client();
            OrderStatus = new OrderStatus();
        }
        /// <summary>
        /// 订单表ID  
        /// </summary>
        public int IdName { get; set; }
        /// <summary>
        /// 餐馆ID
        /// </summary>
        public Restaurant Restaurant { get; set; }
        /// <summary>
        /// 订单总价格
        /// </summary>
        public double TotalPrices { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public Client ClientId { get; set; }
        /// <summary>
        /// 订单状态ID
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// 骑手
        /// </summary>
        public Rider Rider { get; set; }
    }
}
