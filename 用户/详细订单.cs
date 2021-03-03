using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DianCanXiTongBLL;
using DianCanXiTongManager;

namespace 点餐系统
{
    public partial class 详细订单 : Form
    {
        ClientManager cm = new ClientManager();
        ReservationManager reservationService = new ReservationManager();
        public string keyValuePairs = null;
        /// <summary>
        /// 订单编号
        /// </summary>
        public string id { get; set; }
        public 详细订单()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            模糊订单 mhdd = new 模糊订单();
            mhdd.Show();
            this.Close();

        }

        private void 详细订单_Load(object sender, EventArgs e)//显示窗体的时候
        {
            Inquire();//查询订单信息
        }
        public void Inquire() //查询订单信息
        {
            DataTable dt = reservationService.InquireReservation(User.khID, id);

            int j = 0;
            Image asg =null;//这里你要知道有几个菜  我只是随便弄了2个因为数据库里面有两个数据

            foreach (DataRow dr in dt.Rows)//循环表里的行
            {
                asg = System.Drawing.Image.FromFile(Temp.pathCG + dr["CuisineImagePath"].ToString());//已经把拿到的图片保存到了这里面
                lvOrder.Items.Add(dr["CuisineName"] + "(" + dr["CuisinePrice"]+"/元)x"+ dr["VegetableQuantity"], j);//这里是关键!!!!!!!!!倒

                image.Images.Add(asg);//添加图片到上面去
                j++;
            }
            lbTotal.Text = Convert.ToString("总共：" + keyValuePairs + " 元");//计算总价
        }
    }
}
