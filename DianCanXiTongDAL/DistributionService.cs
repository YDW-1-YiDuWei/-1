using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DianCanXiTongDAL
{
    public class DistributionService
    {
        private DBHelper dB = new DBHelper();
        /// <summary>
        /// 配送表
        /// </summary>
        /// <returns></returns>
        public int CuisinelnformationsAddService(string riderId, string cuisineId, string lientId, string restaurantId)
        {
            string sql = "insert into Distribution(RiderId,CuisineId,ClientId,RestaurantId)values(@RiderId,@CuisineId,@ClientId,@RestaurantId)";
            SqlParameter[] sp =
            {
                new SqlParameter("@RiderId",riderId),
                new SqlParameter("@CuisineId",cuisineId),
                new SqlParameter("@ClientId",lientId),
                new SqlParameter("@RestaurantId",restaurantId),
            };
            return dB.ExecuteNonQuery(sql, sp);
        }
    }
}
