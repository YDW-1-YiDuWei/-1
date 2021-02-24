using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongManager;
using System.Data;

namespace DianCanXiTongDAL
{
    /// <summary>
    /// 订单数据层
    /// </summary>
    public class ReservationService
    {
        DBHelper db = new DBHelper();
        public DataTable InquireReservation() //查询详细订单信息
        {
            string sql = "select ci.CuisineImagePath,ci.CuisineName,ci.CuisinePrice,1,0 from Reservation r inner join Client c on c.Id=r.ClientId inner join CuisineInformations ci on r.CuisineInformationId=ci.Id";
            return db.GetTable(sql, "Reservation");
        }
    }
}
