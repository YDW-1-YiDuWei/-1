using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongManager;
using System.Data;
using System.Data.SqlClient;

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
            string sql = "select ci.CuisineImagePath,ci.CuisineName,ci.CuisinePrice,1 from Reservation r inner join Client c on c.Id=r.ClientId inner join CuisineInformations ci on r.CuisineInformationId=ci.Id";
            return db.GetTable(sql, "Reservation");
        }
        public object InquireReservationJG() //返回这个订单总共多少钱
        {
            string sql = "select sum(ci.CuisinePrice) from Reservation r inner join Client c on c.Id=r.ClientId inner join CuisineInformations ci on r.CuisineInformationId=ci.Id";
            
            return db.ExecuteScalar(sql);
        }
        public void SelectReservation()//查询订单
        {
            string sql = " "; 
        }
        /// <summary>
        /// 订单增加
        /// </summary>
        /// <returns></returns> 325
        /// 
        public int AddReservationService(string clientId,string money,string cuisineInformationId)
        {
            string sql = "insert into Reservation(ClientId, Money, CuisineInformationId)values(@ClientId, @Money, @CuisineInformationId)";
            SqlParameter[] sp =
            {
                new SqlParameter("@ClientId",clientId),
                new SqlParameter("@Money",money),
                new SqlParameter("@CuisineInformationId",cuisineInformationId),
            };
            return db.ExecuteNonQuery(sql,sp);
        }
    }
}
