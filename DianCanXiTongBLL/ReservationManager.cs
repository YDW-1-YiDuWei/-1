using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;
using DianCanXiTongManager;
using System.Data;

namespace DianCanXiTongBLL
{
    public class ReservationManager//订单业务层
    {
        ReservationService reservationService = new ReservationService();
        public DataTable InquireReservation(string yHId, string orderListId) //查询详细订单
        {
            return reservationService.InquireReservation(yHId, orderListId);
        }
        public object InquireReservationJG() //查询这个订单总共多少钱
        {
            return reservationService.InquireReservationJG();
        }
        /// <summary>
        /// 订单增加 业务层
        /// </summary>
        /// <returns></returns>
        public int AddReservationManager(string clientId, string money, string cuisineInformationId, string orderListId, string vegetableQuantity)
        {
            return reservationService.AddReservationService(clientId, money, cuisineInformationId, orderListId, vegetableQuantity);
        }

        /// <summary>
        /// 打印订单
        /// </summary>
        /// <returns>序列化操作</returns>
        public int PrintReservationService()
        {
            return reservationService.PrintReservationService();
        }
        /// <summary>
        /// 详细订单删除，业务层
        /// </summary>
        /// <returns></returns>
        public int DeleteReservationManager(string orderListId)
        {
            return reservationService.DeleteReservationService(orderListId);
        }
    }
}
