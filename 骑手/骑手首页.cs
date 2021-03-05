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
using System.IO;
using System.Xml.Serialization;

namespace 点餐系统
{
    public partial class 骑手首页 : Form
    {
        private OrderFormManager ofm = new OrderFormManager();
        public 骑手登入 Get = null;
        private ReservationManager rm = new ReservationManager();
        /// <summary>
        /// 已接订单
        /// </summary>
        public List<OrderForm> of = new List<OrderForm>();

        public 骑手首页()
        {
            InitializeComponent();
            lblQSXM.Text = ":" + User.riderName;
        }
        private void button4_Click(object sender, EventArgs e)//骑手首页 接单（按钮）
        {
            plDD.Visible = true;
            if (lVDD.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中你要，接的订单");
                return;
            }
            if (of.Count == 3)
            {
                MessageBox.Show("您的订单篮已装满，请您送完再来接单哦~~~谢谢配合^.^");
                return;
            }
            OrderForm oof = (OrderForm)lVDD.SelectedItems[0].Tag;

            if (oof.StatusId == 1004)
            {
                MessageBox.Show("订单已被抢了");
                return;
            }


            if (ofm.UpdateOrderFormManager("1004", oof.IdName.ToString(), User.restaId) > 0)
            {
                MessageBox.Show("抢单成功!");
                DDSX();
                of.Add(oof);
            }
        }

        private void button5_Click(object sender, EventArgs e)//骑手首页 已接单（按钮）
        {
            bttJD.Enabled = false;
            lVYDD.Items.Clear();
            if (of.Count == 0) lVYDD.Visible = false;


            foreach (OrderForm item in of)
            {
                if (item.StatusId== 1004 || item.StatusId == 2)
                {
                    string[] a = { item.IdName.ToString(), item.ClientId.Name, item.ClientId.Phone, item.Restaurant.RestaurantName, item.Restaurant.RestaurantPhone };
                    ListViewItem lv = new ListViewItem(a);

                    lv.Tag = item;
                    lVYDD.Items.Add(lv);
                }
                
            }
            plYJD.Visible = true;
            /* panel4.Visible = true;
             dGVYDDD.Visible = true;*/

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)//骑手首页 我的（按键）
        {
            panel2.Visible = true;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)//骑手首页 首页（按键）
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)//骑手首页 切换（按钮）
        {
            骑手登入 qsdr = new 骑手登入();
            qsdr.Show();
        }

        private void button3_Click(object sender, EventArgs e)//骑手首页 修改（按钮）
        {
            骑手注册修改 qsdrxg = new 骑手注册修改();
            qsdrxg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出登录", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button3.Enabled = false;
                label2.Text = "";
                label4.Text = "";
            }
        }

        private void 骑手首页_Load(object sender, EventArgs e)
        {
            DDSX();
        }

        /// <summary>
        /// 订单刷新
        /// </summary>
        public void DDSX()
        {
            lVDD.Items.Clear();

            foreach (OrderForm item in ofm.SelectOrderFormManager("", User.restaKhID, "", "", "", ""))
            {
                if (item.StatusId != 1003)
                {
                    continue;
                }
                string[] st = { item.IdName.ToString(), item.ClientId.Name, item.ClientId.Phone, item.Restaurant.RestaurantName, item.Restaurant.RestaurantPhone };
                ListViewItem lv = new ListViewItem(st);

                lv.Tag = item;
                lVDD.Items.Add(lv);
            }
            QSXQDD();
        }

        /// <summary>
        /// 骑手已抢订单
        /// </summary>
        public void QSXQDD()
        {
            of = ofm.SelectOrderFormManager("","", "", "",User.restaId, "1004");
        }
        /// <summary>
        /// 详细订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LVDD_Click(object sender, EventArgs e)
        {
            images.Images.Clear();
            lVXXDD.Items.Clear();

             DataTable dt = rm.InquireReservation(User.khID, lVDD.SelectedItems[0].Text);
            //这里你要知道有几个菜  我只是随便弄了2个因为数据库里面有两个数据

            int j = 0;
            foreach (DataRow dr in dt.Rows)//循环表里的行
            {

                Image asg = System.Drawing.Image.FromFile(Temp.pathCG + dr["CuisineImagePath"].ToString());//已经把拿到的图片保存到了这里面

                lVXXDD.Items.Add(dr["CuisineName"] + "(" + dr["CuisinePrice"] + "/元)x" + dr["VegetableQuantity"], j);//这里是关键!!!!!!!!!
                j++;
                images.Images.Add(asg);//添加图片到上面去
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            bttJD.Enabled = true;
            plYJD.Visible = false;
            lVYDD.Visible = true ;
        }


        /// <summary>
        /// 更新状态，骑手送餐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button7_Click(object sender, EventArgs e)
        {
            int a = 0;
            foreach (OrderForm item in of)
            {
                a=ofm.UpdateOrderFormManager("2", item.IdName.ToString(),"");
            }
            if (a> 0)
            {
                MessageBox.Show("开始送餐!");
                QSXQDD();
                button5_Click("",null);
            }
        }

        private void 骑手首页_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void BttDDYSD_Click(object sender, EventArgs e)
        {

            if (lVYDD.SelectedItems.Count==0)
            {
                MessageBox.Show("你没选择以送达的订单");
                return;
            }
            OrderForm jd = (OrderForm)lVYDD.SelectedItems[0].Tag;
            if (jd.StatusId != 2)
            {
                MessageBox.Show("订单还没开始，更新开始送单");
                return;
            }

            if (ofm.UpdateOrderFormManager("1005", jd.IdName.ToString() , "")>0)
            {
                MessageBox.Show("送达成功!");
                lVYDD.Items.Clear();

                of.Remove(jd);
                QSXQDD();
                button5_Click("", null);
            }
        }
    }
}
