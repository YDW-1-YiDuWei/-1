using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DianCanXiTongManager;

namespace DianCanXiTongDAL
{
    public class CuisinelnformationsService
    {
        private DBHelper dB = new DBHelper();
        private List<CuisineInformations> ls = new List<CuisineInformations>();
        /// <summary>
        /// 菜品查询
        /// </summary>
        public List<CuisineInformations> CuisinelnformationsSelectService(string leix)
        {
            string sql = "select Id, CuisineName, RestaurantId, CuisineTypeId, CuisinePrice, CuisineCommentId, CuisineCount, CuisineImagePath from CuisineInformations where 1=1";
            if (leix.Trim()!="")
            {
                sql += " and CuisineTypeId="+leix;
            }
            SqlDataReader cmd=dB.ExecuteReader(sql);
            while (cmd.Read())
            {
                CuisineInformations cuisine = new CuisineInformations()
                {
                    id =int.Parse(cmd["Id"].ToString()),
                    CuisineName=cmd["CuisineName"].ToString(),
                    CuisinePrice=cmd["CuisinePrice"].ToString(),
                    CuisineCount=int.Parse(cmd["CuisineCount"].ToString())
                };
            }
            return ls;
        }
    }
}
