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
        /// <summary>
        /// 菜品查询
        /// </summary>
        public List<CuisineInformations> CuisinelnformationsSelectService(string leix,string cuisineInformationsLXName)
        {
            List<CuisineInformations> ls = new List<CuisineInformations>();
            string sql = "select a.Id, CuisineName, RestaurantId, CuisineTypeId, CuisinePrice, CuisineCommentId, CuisineCount, CuisineImagePath from CuisineInformations a join CuisineType b on a.CuisineTypeId=b.Id where 1=1";
            if (leix.Trim() != "")
            {
                sql += " and b.CuisineTypeName='" + leix + "'";
            } else if (cuisineInformationsLXName.Trim()!="")
            {
                sql += " and CuisineName ='"+ cuisineInformationsLXName + "'";
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
                ls.Add(cuisine);
            }
            cmd.Close();
            return ls;
        }
    }
}
