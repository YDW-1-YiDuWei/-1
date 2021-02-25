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
            DataTable dt = reservationService.InquireReservation();

            int j = 0;
            Image[] asg = new Image[8];//这里你要知道有几个菜  我只是随便弄了2个因为数据库里面有两个数据
            int ima = 0;

            foreach (DataRow dr in dt.Rows)//循环表里的行
            {
                string gsName = dr[0].ToString();//菜品图片
                string gsName2 = dr[1].ToString();//菜品名称
                string gsName3 = dr[2].ToString();//菜品价格
                string gsName4 = dr[3].ToString();//菜品数量

                asg[ima++] = System.Drawing.Image.FromFile(Temp.pathCG + dr[0].ToString());//已经把拿到的图片保存到了这里面
                lvOrder.Items.Add(dr[0] + "" + dr[1] + "" + dr[2] + "" + dr[3],j);//这里是关键!!!!!!!!!倒
                j++;
            }
            //lvOrder.Columns.Add("1");
            
            image.Images.AddRange(asg);//添加图片到上面去
            lbTotal.Text = Convert.ToString("总共：" + reservationService.InquireReservationJG() + " 元");//计算总价
        }

        private void lvOrder_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)//鼠标悬浮在上面的时候   还没完成
        {
            //失败品  还是不知道怎么写

           /* if (e.Item.Text!=""){ MessageBox.Show("123"); }
            else {  }
            System.Drawing.Size a = new Size();//把图片变大
            a.Width = 90;
            a.Height = 90;

            //e.Item.ImageList.ImageSize = a;//这里也是测试的也是跟下面一样的
            for (int i = 0; i < image.Images.Count; i++)//全都会变大而且还多加了一个
            {
                image.ImageSize = a;
            }
            Inquire();*/
        }

    }
}
