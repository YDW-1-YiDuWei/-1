using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DianCanXiTongManager;

namespace DianCanXiTongDAL
{
    /// <summary>
    /// 数据层，订单表
    /// </summary>
    public class OrderFormService
    {
        private DBHelper dB = new DBHelper();
        /// <summary>
        /// 数据层，订单表增加
        /// </summary>
        public void AddOrderFormService()
        {

        }

        /// <summary>
        /// 数据层，订单查询表
        /// </summary>
        public List<OrderForm> SelectOrderFormService(string clientId,string restaurant ,string hQ,string sJ,string riderId,string statusId)
        {
            List<OrderForm> ls = new List<OrderForm>();
            string sql = "Select IdName, RestaurantId, TotalPrices, ClientId, a.StatusId,b.Id, RestaurantNumber, RestaurantNumberPwd, RestaurantName, RestaurantAddress, RestaurantPhone, RestaurantComment, RestaurantImage, c.Id, Number, Name, Sex, Phone, Password, Address,d.OrderStatusId, d.StatusName From OrderForm a join Restaurant b on b.Id =a.RestaurantId join Client c on ClientId=c.Id join OrderStatus d on d.OrderStatusId=a.StatusId where 1=1";
            if (clientId.Trim() != "")
            {
                sql += " and ClientId='" + clientId + "'";
            }

            if (restaurant.Trim()!="")
            {
                sql += " and RestaurantId='"+restaurant+"'";
            }
            if (hQ.Trim() != "")
            {
                sql += " order by IdName desc";
            }
            if (sJ.Trim()!="")
            {
                sql = " select top 1 *, NewID() as random from OrderForm order by random";
            }
            if (riderId.Trim()!=""&& statusId.Trim()!="")
            {
                sql += " and a.RiderId='"+ riderId + "' and a.StatusId='"+ statusId + "'";
            }

            SqlDataReader sdr=dB.ExecuteReader(sql);
            while (sdr.Read())
            {
                OrderForm order = new OrderForm
                {
                    IdName = int.Parse(sdr["IdName"].ToString()),
                    Restaurant =
                    {
                        id = int.Parse(sdr["id"].ToString()),
                        RestaurantName = sdr["RestaurantName"].ToString(),
                        RestaurantImage = sdr["RestaurantImage"].ToString(),
                    },
                    TotalPrices = int.Parse(sdr["TotalPrices"].ToString()),
                    ClientId =
                    {
                        Phone = sdr["Phone"].ToString(),
                        Name = sdr["Name"].ToString()
                    },
                    StatusId = int.Parse(sdr["StatusId"].ToString()),
                    OrderStatus =
                    {
                        OrderStatusId=int.Parse (sdr["OrderStatusId"].ToString()),
                        StatusName=sdr["StatusName"].ToString ()
                    }

                };
                ls.Add(order);
                if (hQ.Trim() != "") return ls;
            }
            sdr.Close();
            return ls;
        }

        /// <summary>
        /// 订单,状态，更改
        /// </summary>
        /// <returns></returns>
        public int UpdateOrderFormService(string statusId, string idName,string qSQD)
        {
            string sql = "update OrderForm set StatusId = '"+statusId+ "' where IdName ='"+idName+"'";
            if (qSQD.Trim()!="")
            {
                sql = "update OrderForm set StatusId = '" + statusId + "', RiderId='"+qSQD+"'  where IdName ='" + idName + "'";
            }
            return dB.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 订单增加
        /// </summary>
        /// <returns></returns>
        public int AddOrderFormService(string rstaurantId, string totalPrices, string clientId, string statusId)
        {
            string sql = "insert into OrderForm(RestaurantId, TotalPrices, ClientId, StatusId) values(@RestaurantId,@TotalPrices,@ClientId,@StatusId)";

            SqlParameter[] sp =
            {
                new SqlParameter("@RestaurantId",rstaurantId),
                new SqlParameter("@TotalPrices",totalPrices),
                new SqlParameter("@ClientId",clientId),
                new SqlParameter("@StatusId",statusId)
            };

            return dB.ExecuteNonQuery(sql, sp);
        }
        /// <summary>
        /// 订单删除，数据层
        /// </summary>
        /// <param name="idName"></param>
        /// <returns></returns>
        public int DeleteOrderFormService(string idName)
        {
            string sql = "delete OrderForm where IdName='"+ idName+"'";
            return dB.ExecuteNonQuery(sql);
        }
    }
}
