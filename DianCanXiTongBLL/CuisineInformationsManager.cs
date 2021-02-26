using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;
using DianCanXiTongManager;

namespace DianCanXiTongBLL
{
    public class CuisineInformationsManager//菜品业务层
    {
        private CuisinelnformationsService cS = new CuisinelnformationsService();
        /// <summary>
        /// 点餐查询，业务层
        /// </summary>
        /// <param name="leix"></param>
        public List<CuisineInformations> CuisinelnformationsSelectManager(string canGuanBianHao, string leix,string cuisineInformationsLXName)
        {
            return cS.CuisinelnformationsSelectService(canGuanBianHao,leix, cuisineInformationsLXName);
        }
        /// <summary>
        /// 增加菜品方法
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="cgId">餐馆ID</param>
        /// <param name="lxId">类型ID</param>
        /// <param name="money">菜品价格</param>
        /// <param name="a">菜品评论</param>//删除了评论
        /// <param name="b">菜品次数</param>
        /// <param name="ptho">菜品图片路径</param>
        public int AddCuisineInformations(string name, int cgId, int lxId, decimal money, int b, string ptho) 
        {
            return cS.AddCuisineInformations(name,cgId,lxId,money,b,ptho);
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
        public int AmendCuisineInformations(int id, string name, int lxId, decimal money, string ptho) 
        {
            return cS.AmendCuisineInformations(id,name,lxId,money,ptho);
        }
        public List<CuisineInformations> CuisinelnformationsAmend(string canGuanBianHao, int i) //修改菜品的时候要用
        {
            return cS.CuisinelnformationsAmend(canGuanBianHao, i);
        }
    }
}
