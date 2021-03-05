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

namespace 点餐系统
{
    public partial class 商家首页2 : Form
    {
        public int a = 0;
        public int i = 1;
        int count = 0;

        public CuisineInformationsManager cIM = new CuisineInformationsManager();
        public List<Restaurant> list = null;

        private OrderFormManager of = new OrderFormManager();
        private ReservationManager rm = new ReservationManager();

        private Dictionary<int, int> di = new Dictionary<int, int>();
        /// <summary>
        /// 订单接收
        /// </summary>
        private DataTable dt = null;
        public 商家首页2()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页2  首页（按键）
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;

            if (a == 1)
            {
                MessageBox.Show("请您先登录账号", "登录提示", MessageBoxButtons.OK);
                return;
            }
            i = 1;
            Temp.index = 0;
            btnSerach.Visible = true;
            panel1.Visible = true;//商家首页显示（panel1）
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)//商家首页2  我的（按键）
        {
            i = 1;
            btnSerach.Visible = false;
            panel1.Visible = false;//商家首页显示（panel1）
        }

        private void button5_Click(object sender, EventArgs e)//商家首页2  已完成（按钮）
        {
            i = 1;
            Temp.index = 0;
        }

        private void button2_Click(object sender, EventArgs e)//商家首页2  菜品添加（按钮）
        {
            panel2.Visible = true;
            panel3.Visible = true;
            /*bttJD.Enabled = false;    唐梦石
            bttTD.Enabled = false;      唐梦石
            textBox1.Enabled = true;    唐梦石
            bttCX.Enabled = true;*/   //唐梦石
            i = 1; count = 0;
            Temp.index = 0;
        }
        private void button3_Click(object sender, EventArgs e)//商家首页2  菜品删除（按钮）
        {
            panel2.Visible = true;
            Temp.index = 0;
            i = 0;
            if (lvCPMessage.SelectedIndices.Count == 0)
            {
                return;
            }
            Cmlist.Enabled = true;
            lvCPMessage.ContextMenuStrip = Cmlist;
        }

        private void button6_Click(object sender, EventArgs e)//商家首页2  菜品修改(按钮)
        {
            panel2.Visible = true;
            panel3.Visible = true;
            i = 1;
            count = 1;


            if (lvCPMessage.SelectedItems.Count == 0)//判断有没有选中菜品
            {
                MessageBox.Show("请选择你要修改的菜品");
                return;
            }

            List<CuisineInformations> list = cIM.CuisinelnformationsAmend(User.restaKhID, (int)lvCPMessage.SelectedItems[0].Tag);
            foreach (CuisineInformations item in list)
            {
                txtName.Text = item.CuisineName;//菜品名称
                txtMoney.Text = item.CuisinePrice;//菜品价格
                cbLX.SelectedIndex = item.CuisineTypeId.id;//下拉列表的选择
                pbImage.Image = System.Drawing.Image.FromFile(Temp.pathCG + item.CuisineImagePath);//图片的地址
            }
        }
        private void button7_Click(object sender, EventArgs e)//商家首页2  客户打单(按钮)
        {
            i = 1;

            ReservationManager rese = new ReservationManager();
            int count = rese.PrintReservationService();
            if (count > 0)
            {
                MessageBox.Show("打单成功 数量:" + count);
            }
            else
            {
                MessageBox.Show("你还没有订单哦~~~~~~");
            }
        }

        private void button4_Click(object sender, EventArgs e)//商家首页2  退单(按钮)
        {

        }

        private void button1_Click(object sender, EventArgs e)//商家首页2  接单(按钮)
        {
            i = 1;
        }

        private void button9_Click(object sender, EventArgs e)//商家首页2   菜品添加   确定(按钮)
        {
            if (Check())//判断是否为空
            {
                if (count == 0)
                {
                    int count = cIM.AddCuisineInformations(txtName.Text, int.Parse(User.restaKhID), cbLX.SelectedIndex, decimal.Parse(txtMoney.Text + ".0"), 0, ofdLJ.SafeFileName, 1);
                    if (count > 0)
                    {
                        MessageBox.Show("增加成功");
                        Inquire(); //刷新菜品信息
                        Delete();//删除输入框里面的值
                    }
                    else { MessageBox.Show("增加失败"); }
                }
                else
                {
                    if (Temp.index == 1)//判断有没有重新选择图片
                    {
                        int index = cIM.AmendCuisineInformations((int)lvCPMessage.SelectedItems[0].Tag, txtName.Text, cbLX.SelectedIndex, decimal.Parse(txtMoney.Text), ofdLJ.SafeFileName);
                        if (index > 0)
                        {
                            Temp.index = 0;//把这个重新变成0好以后判断用
                            MessageBox.Show("修改成功");
                            Inquire(); //刷新菜品信息
                            Delete();//删除输入框里面的值
                        }
                        else { MessageBox.Show("修改失败"); }
                    }
                    else
                    {
                        MessageBox.Show("请重新选择图片");
                    }
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)//商家首页2  菜品管理 选择（按钮）
        {
            i = 1;
            if (DialogResult.OK == ofdLJ.ShowDialog())
            {
                pbImage.Image = System.Drawing.Image.FromFile(ofdLJ.FileName);
                Temp.index = 1;
            }
        }



        public bool Check() //商家首页2 菜品添加 菜品管理 判断是否为空
        {
            i = 1;
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品名称");
                txtName.Focus();
                return false;
            }
            if (txtMoney.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品价格");
                txtMoney.Focus();
                return false;
            }
            if (cbLX.SelectedIndex == 0)
            {
                MessageBox.Show("请选择菜品类型");
                cbLX.Focus();
                return false;
            }
            if (pbImage.Image == null)
            {
                MessageBox.Show("请选择菜品图片");
                pbImage.Focus();
                return false;
            }
            return true;
        }
        public void Delete() //清楚输入框里面的值
        {
            txtName.Text = "";
            txtMoney.Text = "";
            cbLX.SelectedIndex = 0;
            pbImage.Image = null;
        }
        public void Inquire() //查询菜品图片
        {

            lvCPMessage.Items.Clear();//清除
            image.Images.Clear();
            List<CuisineInformations> list = cIM.CuisinelnformationsSelectManager(User.restaKhID, "", txtCPName.Text.Trim(), "");

            Image[] asg = new Image[list.Count];//这里是图片的多少
            int i = 0;

            foreach (CuisineInformations item in list)//这里是吧数据库里面的图片和信息循环出来
            {
                //item.CuisineImagePath//图片路径
                string name = item.CuisineTypeId.id == 1 ? "小菜" : item.CuisineTypeId.id == 2 ? "炒菜" : "主食";

                asg[i] = System.Drawing.Image.FromFile(Temp.pathCG + item.CuisineImagePath);//已经把拿到的图片保存到了这里面

                lvCPMessage.Items.Add(item.CuisineName + "    " + name + "    " + item.CuisinePrice, i);//这里是关键!!!!!!!!!把数据倒进lv里面
                lvCPMessage.Items[i].Tag = item.id;
                i++;
            }
            image.Images.AddRange(asg);
        }

        private void btnSerach_Click(object sender, EventArgs e)//商家首页   查询(按钮)
        {
            i = 1;
            Inquire();
        }

        private void 商家首页2_Load(object sender, EventArgs e)//显示窗体的时候
        {
            Inquire();

           // btnquit.Enabled = true;
         //   btnUpdate.Enabled = true;
            label2.Text = DateTime.Now.ToLongDateString().ToString();
            if (list != null)
            {
                User.restaKhID = list[0].id.ToString();
                label1.Text = "商家的名称：" + list[0].RestaurantName;
                pictureBox3.Image = Image.FromFile(Temp.pathCG + list[0].RestaurantImage);
                //txtCGname.Text = list[0].RestaurantName;
                // txtCGnum.Text = User.restaUser;

            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (i == 1)
            {
                lvCPMessage.ContextMenuStrip = null;
            }
            label3.Text = DateTime.Now.ToString("t");
            label2.Text = DateTime.Now.ToString("g");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = (int)lvCPMessage.SelectedItems[0].Tag;
            int count = cIM.DeleteCuisinelnformationsAmend(a);
            if (count > 0)
            {
                MessageBox.Show("删除成功");
                Inquire();//刷新界面
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }
}
