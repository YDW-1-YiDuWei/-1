using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DianCanXiTongManager;

namespace DianCanXiTongDAL
{
    public class CuisinelnformationsService//菜品数据层
    {
        private DBHelper dB = new DBHelper();
        /// <summary>
        /// 菜品查询
        /// </summary>
        public List<CuisineInformations> CuisinelnformationsSelectService(string canGuanBianHao,string leix,string cuisineInformationsLXName,string Id)
        {
            List<CuisineInformations> ls = new List<CuisineInformations>();
            string sql = "select a.Id,VegetableQuantity, CuisineName, RestaurantId, CuisineTypeId, CuisinePrice, CuisineCommentId, CuisineCount, CuisineImagePath from CuisineInformations a join CuisineType b on a.CuisineTypeId=b.Id where RestaurantId=" + canGuanBianHao;

            if (leix.Trim() != "")sql += " and b.CuisineTypeName='" + leix + "'";
            if (cuisineInformationsLXName.Trim() != "")sql += " and CuisineName like '" + cuisineInformationsLXName + "%'";
            if (Id.Trim() != "") sql += " and a.Id='" + Id + "'";

            SqlDataReader cmd=dB.ExecuteReader(sql);
            while (cmd.Read())
            {
                CuisineInformations cuisine = new CuisineInformations()
                {
                    id =int.Parse(cmd["Id"].ToString()),
                    CuisineName=cmd["CuisineName"].ToString(),
                    CuisineTypeId = new CuisineType() {id= int.Parse(cmd["CuisineTypeId"].ToString()) },//邪 加的菜品类型id
                    CuisinePrice = cmd["CuisinePrice"].ToString(),
                    CuisineImagePath= cmd["CuisineImagePath"].ToString(),
                    CuisineCount =int.Parse(cmd["CuisineCount"].ToString()),
                    VegetableQuantity = int.Parse(cmd["VegetableQuantity"].ToString())
                };
                ls.Add(cuisine);
            }
            cmd.Close();
            return ls;
        }
        /// <summary>
        /// 增加菜品
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="cgId">餐馆ID</param>
        /// <param name="lxId">类型ID</param>
        /// <param name="money">菜品价格</param>
        /// <param name="a">菜品评论</param>//删除了评论
        /// <param name="b">菜品次数</param>
        /// <param name="ptho">菜品图片路径</param>
        public int AddCuisineInformations(string name,int cgId, int lxId, decimal money,int b,string ptho) 
        {
            string sql = "  insert  into  CuisineInformations(CuisineName, RestaurantId, CuisineTypeId, CuisinePrice, CuisineCount, CuisineImagePath ) values(@CuisineName, @RestaurantId, @CuisineTypeId, @CuisinePrice, @CuisineCount, @CuisineImagePath)";
            SqlParameter[] sp = new SqlParameter[] 
            {
            new SqlParameter("@CuisineName",name),
            new SqlParameter("@RestaurantId",cgId),
            new SqlParameter("@CuisineTypeId",lxId),
            new SqlParameter("@CuisinePrice",money),
            new SqlParameter("@CuisineCount",b),
            new SqlParameter("@CuisineImagePath",ptho)
            };
            return dB.ExecuteNonQuery(sql,sp);
        }
        /// <summary>
        /// 修改菜品
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="cgId">餐馆ID</param>//修改没有餐馆
        /// <param name="lxId">类型ID</param>
        /// <param name="money">菜品价格</param>
        /// <param name="a">菜品评论</param>//删除了评论
        /// <param name="b">菜品次数</param>//修改没有菜品次数
        /// <param name="ptho">菜品图片路径</param>
        public int AmendCuisineInformations(int id,string name,int lxId, decimal money, string ptho) 
        {
            string sql = "update  CuisineInformations  set CuisineName=@CuisineName, CuisineTypeId=@CuisineTypeId, CuisinePrice=@CuisinePrice,CuisineImagePath=@CuisineImagePath  where CuisineInformations.Id=" + id;
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@CuisineName",name),
            new SqlParameter("@CuisineTypeId",lxId),
            new SqlParameter("@CuisinePrice",money),
            new SqlParameter("@CuisineImagePath",ptho)
            };
            return dB.ExecuteNonQuery(sql,sp);
        }
        public List<CuisineInformations> CuisinelnformationsAmend(string canGuanBianHao, int i)//修改菜品的时候要用
        {
            List<CuisineInformations> ls = new List<CuisineInformations>();
            string sql = "select a.Id, CuisineName, RestaurantId, CuisineTypeId, CuisinePrice, CuisineCommentId, CuisineCount, CuisineImagePath from CuisineInformations a join CuisineType b on a.CuisineTypeId=b.Id where RestaurantId=" + canGuanBianHao;
            
            if (i != -1)
            {
                sql += " and a.Id=" + i;
            }
            SqlDataReader cmd = dB.ExecuteReader(sql);
            while (cmd.Read())
            {
                CuisineInformations cuisine = new CuisineInformations()
                {
                    id = int.Parse(cmd["Id"].ToString()),
                    CuisineName = cmd["CuisineName"].ToString(),
                    CuisineTypeId = new CuisineType() { id = int.Parse(cmd["CuisineTypeId"].ToString()) },//邪 加的菜品类型id
                    CuisinePrice = cmd["CuisinePrice"].ToString(),
                    CuisineImagePath = cmd["CuisineImagePath"].ToString(),
                    CuisineCount = int.Parse(cmd["CuisineCount"].ToString())
                };
                ls.Add(cuisine);
            }
            cmd.Close();
            return ls;
        }

        /// <summary>
        ///  删除菜品
        /// </summary>
        /// <param name="id">菜品编号</param>
        /// <returns></returns>
        public int DeleteCuisineInformations(int id)
        {
            DBHelper dB = new DBHelper();
            string sql = "Delete from CuisineInformations where Id=@Id";
            SqlParameter[] sp =
            {
                new SqlParameter("@Id",id)
            };
            int count = dB.ExecuteNonQuery(sql, sp);
            if (count > 0)
            {
                return count;
            }
            return count;
        }
    }
}
