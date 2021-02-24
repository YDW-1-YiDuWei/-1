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
        public DataTable InquireReservation() //查询详细订单
        {
            return reservationService.InquireReservation();
        }
    }
}
