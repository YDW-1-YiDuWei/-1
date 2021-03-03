using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;
using DianCanXiTongManager;

namespace DianCanXiTongBLL
{
    /// <summary>
    /// 业务层，订单类
    /// </summary>
    public class OrderFormManager
    {
        private OrderFormService ofs = new OrderFormService();
        /// <summary>
        /// 业务层，订单增加方法
        /// </summary>
        public List<OrderForm> SelectOrderFormManager(string clientId, string restaurant,string a)
        {
            return ofs.SelectOrderFormService(clientId, restaurant,a);
        }
        /// <summary>
        /// 订单状态修改，业务层
        /// </summary>
        /// <returns></returns>
        public int UpdateOrderFormManager(string statusId, string idName)
        {
            return ofs.UpdateOrderFormService(statusId, idName);
        }
        public int AddOrderFormManager(string rstaurantId, string totalPrices, string clientId, string statusId)
        {
            return ofs.AddOrderFormService(rstaurantId, totalPrices, clientId, statusId);
        }
        /// <summary>
        /// 订单删除，业务层
        /// </summary>
        /// <param name="idName"></param>
        /// <returns></returns>
        public int DeleteOrderFormManager(string idName)
        {
            return ofs.DeleteOrderFormService(idName);
        }
    }
}
