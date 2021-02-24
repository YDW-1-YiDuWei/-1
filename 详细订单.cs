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
            List<Client>list= cm.Login(User.user,User.pass);//集合用户    测试给你看的
            Inquire();//查询订单信息
        }
        public void Inquire() //查询订单信息
        {
            DataTable dt = reservationService.InquireReservation();

            int j = 0;
            Image[] asg = new Image[2];//这里你要知道有几个菜  我只是随便弄了2个因为数据库里面有两个数据
            int ima = 0;

            foreach (DataRow dr in dt.Rows)//循环表里的行
            {
                string gsName = dr[0].ToString();//菜品图片
                string gsName2 = dr[1].ToString();//菜品名称
                string gsName3 = dr[2].ToString();//菜品价格
                string gsName4 = dr[3].ToString();//菜品数量
                string gsName5 = dr[4].ToString();//小计

                asg[ima++] = System.Drawing.Image.FromFile(Temp.pathCG + gsName);//已经把拿到的图片保存到了这里面
                lvOrder.Items.Add(gsName2 + "       " + gsName3 + "                              " + gsName4+"                    "+gsName5, j);//这里是关键!!!!!!!!!倒

                j++;
            }
            image.Images.AddRange(asg);//添加图片到上面去
            lbTotal.Text = Convert.ToString("总共："+reservationService.InquireReservationJG()+" 元");//计算总价
        }

        private void lvOrder_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)//鼠标悬浮在上面的时候
        {
            System.Drawing.Size a = new Size();//把图片变大
            a.Width = 90;
            a.Height = 90;
            for (int i = 0; i < image.Images.Count; i++)
            {
                image.ImageSize= a;
            }
            Inquire();
        }
    }
}
