using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DianCanXiTongManager;
using System.Data

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
            string sql = "select a.Id, CuisineName, RestaurantId, c.CuisineTypeName, CuisinePrice, CuisineCommentId, CuisineCount, CuisineImagePath from CuisineInformations a join Restaurant b on a.RestaurantId=b.Id join CuisineType c on a.CuisineTypeId=c.Id join CuisineComment d on 1=1  where 1=1";
            if (leix.Trim()!="")
            {
                sql += " and CuisineTypeName=" + leix;
            }
            DataTable dt= dB.GetTable(sql,"Dianc");
            foreach (DataRow dr in dt.Rows)
            {
                CuisineInformations cuisine = new CuisineInformations()
                {
                    id=int.Parse(dr["a.Id"].ToString()),
                    CuisineName =dr["CuisineName"].ToString(),

                };
            }
            return ls;
        }
    }
}
