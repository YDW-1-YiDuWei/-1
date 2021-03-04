using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongManager;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DianCanXiTongDAL
{
    /// <summary>
    /// 订单数据层
    /// </summary>
    public class ReservationService
    {
        DBHelper db = new DBHelper();
        public DataTable InquireReservation(string yHID,string orderListId) //查询详细订单信息
        {
            string sql = "select  r.CuisineInformationId,r.ClientId,r.Money,r.OrderListId,ci.CuisineImagePath,ci.CuisineName,ci.CuisinePrice,r.VegetableQuantity from Reservation r inner join Client c on c.Id=r.ClientId inner join CuisineInformations ci on r.CuisineInformationId=ci.Id where 1=1 ";

            if (yHID .Trim ()!="")sql+= "  and ClientId = '" + yHID + "'";
            if (orderListId.Trim() != "")sql+=" and OrderListId = '" + orderListId + "'"; 

            return db.GetTable(sql, "Reservation");
        }

        /// <summary>
        /// 返回这个订单总共多少钱
        /// </summary>
        /// <returns></returns>
        public object InquireReservationJG() 
        {
            string sql = "select sum(ci.CuisinePrice) from Reservation r inner join Client c on c.Id=r.ClientId inner join CuisineInformations ci on r.CuisineInformationId=ci.Id";

            return db.ExecuteScalar(sql);
        }
        /// <summary>
        /// 订单增加
        /// </summary>
        /// <returns></returns> 325
        /// 
        public int AddReservationService(string clientId, string money, string cuisineInformationId,string orderListId,string vegetableQuantity)
        {
            string sql = "insert into Reservation(ClientId, Money, CuisineInformationId,OrderListId,VegetableQuantity)values(@ClientId, @Money, @CuisineInformationId,@OrderListId,@VegetableQuantity)";
            SqlParameter[] sp =
            {
                new SqlParameter("@ClientId",clientId),
                new SqlParameter("@Money",money),
                new SqlParameter("@CuisineInformationId",cuisineInformationId),
                new SqlParameter("@OrderListId",orderListId),
                new SqlParameter("@VegetableQuantity",vegetableQuantity),
            };
            return db.ExecuteNonQuery(sql, sp);
        }

        /// <summary>
        /// 打印订单
        /// </summary>
        /// <returns>序列化操作</returns>
        public int PrintReservationService()
        {
            int i = 0;
            DBHelper db = new DBHelper();

            string sql = "select r.Id,c.Name, Money, s.CuisineName,c.Phone,c.Address from Reservation r  join Client c on c.Id = r.ClientId join CuisineInformations s on s.Id = r.CuisineInformationId";

            SqlDataReader sdr = db.ExecuteReader(sql);
            while (sdr.Read())
            {
                string name = sdr["Name"].ToString();
                decimal mony = decimal.Parse(sdr["Money"].ToString());
                string reservationName = sdr["CuisineName"].ToString();
                string phone = sdr["Phone"].ToString();
                string address = sdr["Address"].ToString();

                using (FileStream fs = new FileStream("" + name + ".txt", FileMode.Create, FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("***************************");
                    sw.WriteLine("菜品名称：   " + reservationName);
                    sw.WriteLine("-------------------------- -");
                    sw.WriteLine("费用金额：   " + mony);
                    sw.WriteLine("收货地址：   " + address);
                    sw.WriteLine("联系电话：   " + phone);
                    sw.WriteLine("  收货人：   " + name);
                    sw.WriteLine("****************************");
                    sw.Close();
                }
                i++;
            }
            return i;
        }//打印订单
        /// <summary>
        /// 详细订单删除，数据层
        /// </summary>
        /// <returns></returns>
        public int DeleteReservationService(string orderListId)
        {
            string sql = "delete Reservation where OrderListId='"+orderListId+"'";
            return db.ExecuteNonQuery(sql);
        }
    }
}
