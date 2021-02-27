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
        public DataTable InquireReservation(string yHId) //查询详细订单
        {
            return reservationService.InquireReservation(yHId);
        }
        public object InquireReservationJG() //查询这个订单总共多少钱
        {
            return reservationService.InquireReservationJG();
        }
        /// <summary>
        /// 订单增加 业务层
        /// </summary>
        /// <returns></returns>
        public int AddReservationManager(string clientId, string money, string cuisineInformationId)
        {
            return reservationService.AddReservationService(clientId, money, cuisineInformationId);
        }

        /// <summary>
        /// 打印订单
        /// </summary>
        /// <returns>序列化操作</returns>
        public int PrintReservationService()
        {
            return reservationService.PrintReservationService();
        }
    }
}
